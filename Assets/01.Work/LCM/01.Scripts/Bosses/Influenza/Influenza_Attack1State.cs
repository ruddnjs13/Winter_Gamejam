using UnityEngine;

public class Influenza_Attack1State : BossState
{
    private Transform target;
    private Vector2 _moveDir;
    public Influenza_Attack1State(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        target = _influenza.GetPlayerPosition();
        _moveDir = (target.position - _influenza.transform.position).normalized;
    }

    public override void FixedUpdateState(){
        _influenza.RbCompo.linearVelocity = _moveDir * _influenza.RbCompo.linearVelocity;
    }
}
