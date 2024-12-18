using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public Rigidbody2D RbCompo { get; private set; }
    
    protected Dictionary<BossStateType, BossState> StateEnum = new Dictionary<BossStateType, BossState>();
    public BossStateType CurrentState { get; private set; }

    protected virtual void Awake(){
        RbCompo = GetComponent<Rigidbody2D>();
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
}
