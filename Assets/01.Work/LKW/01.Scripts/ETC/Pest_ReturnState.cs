using UnityEngine;

public class Pest_ReturnState : BossState{
    private Vector2 _moveDir;
    private Vector2 _nowPos;
    private float epsilon = 0.03f;
    public Pest_ReturnState(Pest pest) : base(pest){
    }

    protected override void EnterState(){
        _pest.RbCompo.linearVelocity = Vector2.zero;
        _moveDir = _pest.DefaultTransform - _pest.transform.position;
        Debug.Log(_pest.DefaultTransform);
    }

    public override void FixedUpdateState(){
        _pest.RbCompo.linearVelocity = _moveDir.normalized * 3;
    }

    public override void UpdateState(){
        _nowPos = _pest.transform.position;
        if (Mathf.Abs(_nowPos.x) < epsilon && Mathf.Abs(_nowPos.y) < epsilon)
        {
            _pest.TransitionState(BossStateType.Idle);
            
        }
    }

    protected override void ExitState(){
        _pest.RbCompo.linearVelocity = Vector2.zero;
    }
}