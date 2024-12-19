using UnityEngine;

public class SmallPox_Attack1State : BossState
{
    public SmallPox_Attack1State(SmallPox smallPox) : base(smallPox){
    }
    private Transform _target;
    private Vector2 _moveDir;
    private float _waitTime = 1.5f;
    private float _waitTimeCounter;
    private bool _isHit = false;

    protected override void EnterState(){
        _smallPox.RbCompo.linearVelocity = Vector2.zero;
        _target = _smallPox.GetPlayerPosition();
        _moveDir = (_target.position - _smallPox.transform.position).normalized;
    }

    public override void FixedUpdateState(){
        _smallPox.RbCompo.linearVelocity = _moveDir * _smallPox.SmallPoxData.moveSpeed;
        if (Physics2D.OverlapCircle(_smallPox.transform.position,_smallPox.SmallPoxData.checkGroundRadius, _smallPox._whatIsGround))
        {
            Collider2D collider2D = Physics2D.OverlapCircle(_smallPox.transform.position,
                _smallPox.SmallPoxData.checkGroundRadius, _smallPox._whatIsGround);

            Vector2 pos = collider2D.ClosestPoint(_smallPox.transform.position);
            
            if(_isHit == false)
                _smallPox.InstatiateCollisionParticle(pos);
            _isHit = true;
        }
    }

    public override void UpdateState(){
        if (_isHit)
        {
            _waitTimeCounter += Time.deltaTime;
            if (_waitTimeCounter >= _waitTime)
            {
                _waitTimeCounter = 0;
                _smallPox.TransitionState(BossStateType.Return);
            }
        }
    }
}
