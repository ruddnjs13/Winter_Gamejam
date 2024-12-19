using UnityEngine;

public class SmallPox_IdleState : BossState
{
    public SmallPox_IdleState(SmallPox smallPox) : base(smallPox){
    }
    
    protected override void EnterState(){
        _smallPox.RbCompo.linearVelocity = Vector2.zero;
        _smallPox.RandomAttack();
    }
}
