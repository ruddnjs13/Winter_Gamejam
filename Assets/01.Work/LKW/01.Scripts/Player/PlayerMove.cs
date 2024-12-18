using System;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(float moveX)
    {
        _rigidbody.linearVelocity = transform.right * moveX;
    }
}
