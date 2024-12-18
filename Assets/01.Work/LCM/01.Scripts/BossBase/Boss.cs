using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour{
    [SerializeField] private Vector2 _playerCheckerBoxSize;
    [SerializeField] private LayerMask _whatIsPlayer;

    public Rigidbody2D RbCompo { get; private set; }
    public BossAnimationPlay AnimationPlay { get; private set; }
    
    protected Dictionary<BossStateType, BossState> StateEnum = new Dictionary<BossStateType, BossState>();
    public BossStateType CurrentState { get; private set; }

    protected virtual void Awake(){
        RbCompo = GetComponent<Rigidbody2D>();
        AnimationPlay = GetComponentInChildren<BossAnimationPlay>();
    }
    
    public void TransitionState(BossStateType newState)
    {
        StateEnum[CurrentState].Exit();
        CurrentState = newState;
        StateEnum[CurrentState].Enter();
    }

    private void Update()
    {
        StateEnum[CurrentState].UpdateState();
    }

    private void FixedUpdate()
    {
        StateEnum[CurrentState].FixedUpdateState();
    }

    public Transform GetPlayerPosition(){
        Collider2D playerCollider = Physics2D.OverlapBox(transform.position, _playerCheckerBoxSize, 0f, _whatIsPlayer);
        return playerCollider.transform;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _playerCheckerBoxSize);
    }
}
