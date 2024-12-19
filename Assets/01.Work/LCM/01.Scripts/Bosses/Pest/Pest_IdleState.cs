using UnityEngine;

public class Pest_IdleState : BossState
{
    public Pest_IdleState(Pest pest) : base(pest){
    }

    protected override void EnterState()
    {
        Debug.Log("Pest_IdleState EnterState");
        _pest.RbCompo.linearVelocity = Vector2.zero;
        _pest.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        _pest.RandomAttack();
    }
}
