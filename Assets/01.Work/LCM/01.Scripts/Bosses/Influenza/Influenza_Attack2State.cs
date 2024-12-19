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
            BossProjectile bossProjectile =  PoolManager.Instance.Pop("BossProjectile1") as BossProjectile;
            bossProjectile.transform.position = _influenza.transform.position;
            bossProjectile.transform.rotation = _influenza.transform.rotation;
            _curTime = 0;
            attackCount++;
        }

        if (attackCount >= _influenza.InfluenzaData.Attack2Count)
        {
            attackCount = 0;
            _influenza.TransitionState(BossStateType.Idle);
        }
    }
}
