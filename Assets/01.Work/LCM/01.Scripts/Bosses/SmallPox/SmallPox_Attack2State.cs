using UnityEngine;

public class SmallPox_Attack2State : BossState
{
    private Vector2 _moveDir;
    public SmallPox_Attack2State(SmallPox smallPox) : base(smallPox){
    }

    protected override void EnterState(){
        _moveDir = _smallPox.TargetingPlayer;
        
    }

    public override void FixedUpdateState(){
        _smallPox.RbCompo.linearVelocity = _moveDir.normalized * _smallPox.SmallPoxData.moveSpeed;
        if (_smallPox.Count == 0 && _smallPox.CheckStart)
        {
            Debug.Log("리턴으로 이동");
            _smallPox.CheckStart = false;
            _smallPox.TransitionState(BossStateType.Return);
        }

        if (_smallPox.Count != 0 && _smallPox.CheckStart)
        {
            _moveDir = _smallPox.TargetingPlayer;
        }
    }
}
