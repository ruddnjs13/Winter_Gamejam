using UnityEngine;

public class SmallPox_ReturnState : BossState
{
    public SmallPox_ReturnState(SmallPox smallPox) : base(smallPox){
    }
    
    private Vector2 _moveDir;
    private Vector2 _nowPos;
    private float epsilon = 0.03f;

    protected override void EnterState(){
        _smallPox.RbCompo.linearVelocity = Vector2.zero;
        _moveDir = _smallPox.DefaultTransform - _smallPox.transform.position;
    }

    public override void FixedUpdateState(){
        _smallPox.RbCompo.linearVelocity = _moveDir.normalized * _smallPox.SmallPoxData.returnSpeed;
    }

    public override void UpdateState(){
        _nowPos = _smallPox.transform.position;
        if (Mathf.Abs(_nowPos.x) < epsilon && Mathf.Abs(_nowPos.y) < epsilon)
        {
            _smallPox.TransitionState(BossStateType.Idle);
        }
    }

    protected override void ExitState(){
        _smallPox.RbCompo.linearVelocity = Vector2.zero;
    }
}
