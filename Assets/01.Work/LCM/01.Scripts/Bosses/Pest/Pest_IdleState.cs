using UnityEngine;

public class Pest_IdleState : BossState
{
    public Pest_IdleState(Pest pest) : base(pest){
    }

    protected override void EnterState(){
        _pest.RbCompo.linearVelocity = Vector2.zero;
    }
}
