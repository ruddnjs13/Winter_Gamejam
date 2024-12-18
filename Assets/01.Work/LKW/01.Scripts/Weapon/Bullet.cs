using System;
using UnityEngine;

public class Bullet : MonoBehaviour,IPoolable
{
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private LayerMask _whatIsTarget;
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
        Debug.Log("충돌함");
        if ((0 << collision.gameObject.layer & _whatIsTarget) != 0)
        {
            PoolManager.Instance.Push(collision as IPoolable);
            PoolManager.Instance.Push(this);
        }
        else if (collision.CompareTag("Ground"))
        {
            Debug.Log("푸시");
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
