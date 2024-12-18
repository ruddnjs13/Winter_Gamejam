using UnityEngine;

public class Influenza_IdleState : BossState
{
    public Influenza_IdleState(Influenza smallPox) : base(smallPox){
    }

    protected override void EnterState(){
        _influenza.RandomAttack();
    }
}
