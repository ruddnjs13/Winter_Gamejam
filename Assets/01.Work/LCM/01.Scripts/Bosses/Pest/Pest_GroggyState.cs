using UnityEngine;
using DG.Tweening;

public class Pest_GroggyState : BossState
{
    private float _curTime;
    private float _checkTime = 1f;
    
    public Pest_GroggyState(Pest pest) : base(pest){
    }
    
    protected override void EnterState(){
        _pest.RbCompo.linearVelocity = Vector2.zero;
    }

    public override void UpdateState(){
        _curTime += Time.deltaTime;
        if (_curTime >= _checkTime)
        {
            _pest.IsCanDie = true;
            _pest.transform.DOShakePosition(0.3f, new Vector3(0.2f, 0.2f, 0f));
            _curTime = 0f;
        }
    }
}
