using UnityEngine;

public class Pest_Attack1State : BossState
{
    private float _curTime;
    private int attackCount;
    public Pest_Attack1State(Pest pest) : base(pest){
    }

    protected override void EnterState(){
        _pest.RbCompo.linearVelocity = Vector2.zero;
    }
    
    public override void UpdateState(){
        _pest.transform.Rotate(0,0,_pest.PestData.rotationSpeed * Time.deltaTime);
        _curTime += Time.deltaTime;
        if (_curTime >= _pest.PestData.Attack1Speed)
        {
            BossProjectile bossProjectile1 =  PoolManager.Instance.Pop("BossProjectile3") as BossProjectile;
            bossProjectile1.transform.position = _pest.transform.position;
            bossProjectile1.transform.rotation = _influenza.transform.rotation;
            BossProjectile bossProjectile2 =  PoolManager.Instance.Pop("BossProjectile3") as BossProjectile;
            bossProjectile2.transform.position = _pest.transform.position;
            bossProjectile2.transform.rotation = Quaternion.Euler(_influenza.transform.rotation.x,_influenza.transform.rotation.y, _influenza.transform.rotation.z - 180f);
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
