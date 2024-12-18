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
        _pest.RotationObject.transform.Rotate(0,0,_pest.PestData.rotationSpeed * Time.deltaTime);
        _curTime += Time.deltaTime;
        if (_curTime >= _pest.PestData.Attack1Speed)
        {
            BossProjectile bossProjectile1 =  PoolManager.Instance.Pop("BossProjectile3") as BossProjectile;
            bossProjectile1.transform.position = _pest.transform.position;
            bossProjectile1.transform.rotation = _pest.RotationObject.transform.rotation;
            BossProjectile bossProjectile2 =  PoolManager.Instance.Pop("BossProjectile3") as BossProjectile;
            bossProjectile2.transform.position = _pest.transform.position;
            bossProjectile2.transform.rotation = Quaternion.Euler(_pest.transform.rotation.x,_pest.transform.rotation.y, _pest.RotationObject.transform.eulerAngles.z - 180f);
            BossProjectile bossProjectile3 =  PoolManager.Instance.Pop("BossProjectile3") as BossProjectile;
            bossProjectile3.transform.position = _pest.transform.position;
            bossProjectile3.transform.rotation = Quaternion.Euler(_pest.transform.rotation.x,_pest.transform.rotation.y, _pest.RotationObject.transform.eulerAngles.z - 90f);
            BossProjectile bossProjectile4 =  PoolManager.Instance.Pop("BossProjectile3") as BossProjectile;
            bossProjectile4.transform.position = _pest.transform.position;
            bossProjectile4.transform.rotation = Quaternion.Euler(_pest.transform.rotation.x,_pest.transform.rotation.y, _pest.RotationObject.transform.eulerAngles.z + 90f);
            _curTime = 0f;
            attackCount++;
        }

        if (attackCount >= _pest.PestData.Attack1Count)
        {
            attackCount = 0;
            _pest.TransitionState(BossStateType.Idle);
        }
    }
}
