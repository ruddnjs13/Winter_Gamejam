using System;
using UnityEngine;

public class Bullet : MonoBehaviour,IPoolable
{
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private int _moveSpeed;
    public string PoolName => objectPrefab.name;
    public GameObject objectPrefab => gameObject;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) return;
        if (collision.CompareTag("Boss") || collision.CompareTag("Ground"))
        {
            PoolManager.Instance.Push(this);
        }
        else
        {
            PoolManager.Instance.Push(this);
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody.linearVelocity = velocity * _moveSpeed;
    }

    public void ResetItem()
    {
        _rigidbody.linearVelocity = Vector2.zero;
    }
}
