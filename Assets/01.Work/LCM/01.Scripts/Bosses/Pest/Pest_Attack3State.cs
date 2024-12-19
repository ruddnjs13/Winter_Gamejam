using UnityEngine;
using DG.Tweening;

public class Pest_Attack3State : BossState
{
    Vector2 _dashDir = Vector2.zero;
    private bool _isHit = false;
    private float _waitTimeCounter;

    public Pest_Attack3State(Pest pest) : base(pest){
    }

    protected override void EnterState()
    {
        base.EnterState();
        _pest.transform.DOMoveY(_pest.transform.position.y + 0.5f, 1.2f)
            .SetEase(Ease.OutBounce)
            .SetLoops(2, LoopType.Yoyo);
        
        int directionIdx = Random.Range(0, 4);

        if (directionIdx == 0)
        {
            _dashDir = Vector2.right;
        }
        else if (directionIdx == 1)
        {
            _dashDir = Vector2.up;
        }
        else if (directionIdx == 2)
        {
            _dashDir = Vector2.left;
        }
        else
        {
            _dashDir = Vector2.down;
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_isHit)
        {
            _waitTimeCounter += Time.deltaTime;
            if (_waitTimeCounter >= 3)
            {
                _waitTimeCounter = 0;
                _pest.TransitionState(BossStateType.Return);
            }
        }
       
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        
        _pest.RbCompo.linearVelocity = _dashDir * _pest.PestData.dashSpeed;
        if (_isHit) return;
        RaycastHit2D hit = Physics2D.Raycast(_pest.transform.position, _dashDir,1.2f, _pest._whatIsGround);
        if (hit.collider != null)
        {
            _pest.WallAttackCompo.WallWave(hit.collider.gameObject.transform
                ,hit.collider.transform.InverseTransformPoint(hit.point).x, hit.collider.transform.localRotation);
            _isHit = true;
        }
    }

    protected override void ExitState()
    {
        _isHit = false;
        _pest.StopAllCoroutines();
        base.ExitState();
    }
}
