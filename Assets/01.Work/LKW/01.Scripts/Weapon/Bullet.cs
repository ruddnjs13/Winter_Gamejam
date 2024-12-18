using System;
using UnityEngine;

public class Bullet : MonoBehaviour,IPoolable
{
    [SerializeField] private LayerMask _whatIsTarget;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private int _moveSpeed;
    public string PoolName => objectPrefab.name;
    public GameObject objectPrefab => gameObject;


    private void Update()
    {
        transform.position += transform.right * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((0 << collision.gameObject.layer & _whatIsTarget) != 0)
        {
            PoolManager.Instance.Push(collision as IPoolable);
            PoolManager.Instance.Push(this);
        }
        else if ((0 << collision.gameObject.layer & _whatIsGround) != 0)
        {
            PoolManager.Instance.Push(this);
        }
    }

    public void ResetItem()
    {
    }
}
