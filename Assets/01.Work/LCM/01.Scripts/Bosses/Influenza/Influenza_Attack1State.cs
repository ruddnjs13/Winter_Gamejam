using UnityEngine;

public class Influenza_Attack1State : BossState
{
    private Transform _target;
    private Vector2 _moveDir;
    private float _waitTime = 1.5f;
    private float _waitTimeCounter;
    private bool _isHit = false;
    public Influenza_Attack1State(Influenza influenza) : base(influenza){
    }

    protected override void EnterState(){
        _influenza.RbCompo.linearVelocity = Vector2.zero;
        _target = _influenza.GetPlayerPosition();
        _moveDir = (_target.position - _influenza.transform.position).normalized;
    }

    public override void FixedUpdateState(){
        _influenza.RbCompo.linearVelocity = _moveDir * _influenza.InfluenzaData.moveSpeed;
        if (Physics2D.OverlapCircle(_influenza.transform.position,_influenza.InfluenzaData.checkGroundRadius, _influenza._whatIsGround))
        {
            _isHit = true;
            _influenza.RbCompo.linearVelocity = Vector2.zero;
        }
    }

    public override void UpdateState(){
        if (_isHit)
        {
            _waitTimeCounter += Time.deltaTime;
            if(_waitTimeCounter >= _waitTime)
                _influenza.TransitionState(BossStateType.Return);
        }
    }
}
