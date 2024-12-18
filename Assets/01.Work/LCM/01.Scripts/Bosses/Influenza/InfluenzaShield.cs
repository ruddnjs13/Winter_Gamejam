using System;
using UnityEngine;

public class InfluenzaShield : MonoBehaviour
{
    private Influenza _influenza;

    private void Awake(){
        _influenza = FindAnyObjectByType<Influenza>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Weapon"))
        {
            _influenza.RemoveList(gameObject);
            if(_influenza.shields.Count == 0)
                _influenza.TransitionState(BossStateType.Groggy);
            Destroy(gameObject);
        }
    }
}
