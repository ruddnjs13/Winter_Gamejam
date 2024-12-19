using UnityEngine;
using DG.Tweening;

public class SmallPox_GroggyState : BossState
{
    private float _curTime;
    private float _checkTime = 1f;
    public SmallPox_GroggyState(SmallPox smallPox) : base(smallPox){
    }
    
    protected override void EnterState(){
        _smallPox.RbCompo.linearVelocity = Vector2.zero;
    }

    public override void UpdateState(){
        _curTime += Time.deltaTime;
        if (_curTime >= _checkTime)
        {
            _smallPox.IsCanDie = true;
            _smallPox.transform.DOShakePosition(0.3f, new Vector3(0.2f, 0.2f, 0f));
            _curTime = 0f;
        }
    }
}
