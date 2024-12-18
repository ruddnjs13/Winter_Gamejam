using System;
using UnityEngine;

public class PestShield : MonoBehaviour{
    private Pest _pest;

    private void Awake(){
        _pest = FindAnyObjectByType<Pest>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Weapon"))
        {
            _pest.RemoveList(gameObject);
            if(_pest.shields.Count == 0)
                _pest.TransitionState(BossStateType.Groggy);
            Destroy(gameObject);
        }
    }
}
