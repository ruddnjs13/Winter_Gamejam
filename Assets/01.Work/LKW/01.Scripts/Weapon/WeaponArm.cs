using System;
using Unity.Mathematics;
using UnityEngine;

public class WeaponArm : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;

    private void Update()
    {
        Debug.Log(_inputReader.MousePos);
        Vector2 dir = (_inputReader.MousePos - (Vector2)transform.position).normalized;
        transform.localRotation = quaternion.Euler(0,0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    }
}
