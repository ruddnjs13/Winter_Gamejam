using UnityEngine;

public class SmallPox_Attack3State : BossState{
    private Vector2 _moveDir;
    private float _curTime;
    private float _changeTime = 2f;
    public SmallPox_Attack3State(SmallPox smallPox) : base(smallPox){
    }

    protected override void EnterState(){
        BossProjectile bossProjectile =  PoolManager.Instance.Pop("BossProjectile4") as BossProjectile;
        _moveDir = _smallPox.GetPlayerPosition().position - _smallPox.transform.position;
        float angle = Mathf.Atan2(_moveDir.y, _moveDir.x) * Mathf.Rad2Deg;
        bossProjectile.transform.position = _smallPox.transform.position;
        bossProjectile.transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public override void UpdateState(){
        _curTime += Time.deltaTime;
        if (_curTime >= _changeTime)
        {
            _curTime = 0;
            _smallPox.TransitionState(BossStateType.Idle);
        }
    }
}
