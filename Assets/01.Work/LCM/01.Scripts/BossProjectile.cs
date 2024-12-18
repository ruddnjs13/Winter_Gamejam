using System;
using UnityEngine;

public class BossProjectile : MonoBehaviour,IPoolable
{
    public GameObject objectPrefab => gameObject;
    public string PoolName => objectPrefab.name;
    public void ResetItem(){
    }

    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidbody2D;
    
    private void Awake(){
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        _rigidbody2D.linearVelocity = transform.right * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground"))
        {
            PoolManager.Instance.Push(this);
        }
    }
}
