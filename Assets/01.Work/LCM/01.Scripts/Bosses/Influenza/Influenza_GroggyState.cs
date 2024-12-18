using UnityEngine;
using DG.Tweening;

public class Influenza_GroggyState : BossState{
    private float _curTime;
    private float _checkTime = 1f;
    
    public Influenza_GroggyState(Influenza smallPox) : base(smallPox){
    }

    protected override void EnterState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
    }

    public override void UpdateState(){
        _curTime += Time.deltaTime;
        if (_curTime >= _checkTime)
        {
            _influenza.IsCanDie = true;
            _influenza.transform.DOShakePosition(0.3f, new Vector3(0.2f, 0.2f, 0f));
            _curTime = 0f;
        }
    }
}
