using UnityEngine;

public class Influenza_ReturnState : BossState{
    private Vector2 _moveDir;
    
    public Influenza_ReturnState(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
        _moveDir = _influenza.DefaultTransform.position - _influenza.transform.position;
    }

    public override void FixedUpdateState(){
        _influenza.RbCompo.linearVelocity = _moveDir.normalized * _influenza.InfluenzaData.returnSpeed;
        if(_influenza.transform.position == _influenza.DefaultTransform.position)
            _influenza.TransitionState(BossStateType.Idle);
    }

    protected override void ExitState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
    }
}
