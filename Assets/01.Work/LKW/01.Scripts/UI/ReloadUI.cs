using Unity.Mathematics;
using UnityEngine;

public class ReloadUI : MonoBehaviour
{
    [SerializeField] private GameObject _bar;


    public void Flip(bool isFacingRight)
    {
        if (isFacingRight)
            transform.localRotation = quaternion.identity;
        else
            transform.localRotation = quaternion.Euler(new Vector3(0, 236f, 0));
        
    }
    public void SetValue(float value)
    {
        _bar.transform.localScale = new Vector3(value, 0.5f, 1);
    }
}
