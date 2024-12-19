using System;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    private readonly int _moveXHash = Animator.StringToHash("MoveX");
    private readonly int _deadHash = Animator.StringToHash("Dead");
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveXHash(float moveX)
    {
        _animator.SetFloat(_moveXHash, moveX);
    }

    public void SetDead()
    {
        _animator.SetTrigger(_deadHash);
    }

    public void Flip(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.parent.localScale = new Vector3(1,1,1);
        }
        else
        {
            transform.parent.localScale = new Vector3(-1,1,1);
        }
    }
    
    public void PlayerDead()
    {
        GetComponentInParent<Player>().DeadEvent?.Invoke();
    }
}
