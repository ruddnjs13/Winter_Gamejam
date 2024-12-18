using UnityEngine;

public class Influenza_Attack3State : BossState
{
    private float _curTime;
    private int attackCount;
    private Vector2 _moveDir;
    public Influenza_Attack3State(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
    }
    
    public override void UpdateState(){
        _influenza.transform.Rotate(0,0,-_influenza.InfluenzaData.rotationSpeed * Time.deltaTime);
        _curTime += Time.deltaTime;
        if (_curTime >= _influenza.InfluenzaData.Attack3Speed)
        {
            BossProjectile bossProjectile =  PoolManager.Instance.Pop("BossProjectile2") as BossProjectile;
            _moveDir = _influenza.GetPlayerPosition().position - _influenza.transform.position;
            float angle = Mathf.Atan2(_moveDir.y, _moveDir.x) * Mathf.Rad2Deg;
            bossProjectile.transform.position = _influenza.transform.position;
            bossProjectile.transform.rotation = Quaternion.Euler(0,0,angle);
            _curTime = 0;
            attackCount++;
        }

        if (attackCount >= _influenza.InfluenzaData.Attack3Count)
        {
            attackCount = 0;
            _influenza.TransitionState(BossStateType.Idle);
        }
    }
}
