using System;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    private readonly int _moveXHash = Animator.StringToHash("MoveX");
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveXHash(float moveX)
    {
        _animator.SetFloat(_moveXHash, moveX);
    }

    public void Flip(float moveX)
    {
        if(Mathf.Abs(moveX) <= 0) return;
        transform.parent.localScale = new Vector3(moveX* transform.parent.localScale.x
            , transform.parent.localScale.y, transform.parent.localScale.z);
    }
}
