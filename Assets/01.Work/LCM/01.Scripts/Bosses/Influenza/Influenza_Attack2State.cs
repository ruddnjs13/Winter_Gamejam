using UnityEngine;

public class Influenza_Attack2State : BossState{
    private float _curTime;
    private int attackCount;
    public Influenza_Attack2State(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
    }

    public override void UpdateState(){
        _influenza.transform.Rotate(0,0,_influenza.InfluenzaData.rotationSpeed * Time.deltaTime);
        _curTime += Time.deltaTime;
        if (_curTime >= _influenza.InfluenzaData.Attack2Speed)
        {
            
            _curTime = 0;
            attackCount++;
        }
        if(attackCount >= _influenza.InfluenzaData.Attack2Count)
            _influenza.TransitionState(BossStateType.Idle);
    }
}
