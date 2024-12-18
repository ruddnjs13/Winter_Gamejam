using UnityEngine;

public class BossState{
    protected Pest _pest;

    public BossState(Pest pest){
        _pest = pest;
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
    Idle
}
