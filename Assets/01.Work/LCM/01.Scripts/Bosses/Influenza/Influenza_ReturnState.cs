using UnityEngine;

public class Influenza_ReturnState : BossState{
    private Vector2 _moveDir;
    private Vector2 _nowPos;
    private float epsilon = 0.03f;
    public Influenza_ReturnState(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
        _moveDir = _influenza.DefaultTransform - _influenza.transform.position;
    }

    public override void FixedUpdateState(){
        _influenza.RbCompo.linearVelocity = _moveDir.normalized * _influenza.InfluenzaData.returnSpeed;
    }

    public override void UpdateState(){
        _nowPos = _influenza.transform.position;
        if (Mathf.Abs(_nowPos.x) < epsilon && Mathf.Abs(_nowPos.y) < epsilon)
        {
            _influenza.TransitionState(BossStateType.Idle);
        }
    }

    protected override void ExitState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
    }
}
