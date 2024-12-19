using UnityEngine;

public class Influenza_IdleState : BossState
{
    public Influenza_IdleState(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        _influenza.RandomAttack();
    }
}
