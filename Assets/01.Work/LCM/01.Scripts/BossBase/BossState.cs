using UnityEngine;

public class BossState{
    protected Pest _pest;
    protected SmallPox _smallPox;
    protected Influenza _influenza;

    public BossState(Pest pest){
        _pest = pest;
    }

    public BossState(SmallPox smallPox){
        _smallPox = smallPox;
    }

    public BossState(Influenza influenza){
        _influenza = influenza;
    }
    
    protected virtual void EnterState()
    {

    }

    public void Enter()
    {
        EnterState();
    }

    public virtual void UpdateState()
    {

    }
    public virtual void FixedUpdateState()
    {

    }

    protected virtual void ExitState()
    {

    }

    public void Exit()
    {
        ExitState();
    }
}

public enum BossStateType
{
    Idle,
    Attack1,
    Attack2,
    Attack3,
    Attack4
}
