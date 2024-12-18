using System;
using UnityEngine;

public class PestShieldParent : MonoBehaviour{
    [SerializeField] private float speed;

    private void FixedUpdate(){
        transform.Rotate(0,0,speed*Time.fixedDeltaTime);
    }
}
