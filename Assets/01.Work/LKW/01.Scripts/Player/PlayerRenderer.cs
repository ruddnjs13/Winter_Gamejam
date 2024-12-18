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

    public void Flip(float move)
    {
        if(Mathf.Abs(move) <= 0) return;
        bool isFacingRight = move > 0;

        if (isFacingRight)
        {
            transform.parent.localScale = new Vector3(1,1,1);
        }
        else
        {
            transform.parent.localScale = new Vector3(-1,1,1);
        }
    }
}
