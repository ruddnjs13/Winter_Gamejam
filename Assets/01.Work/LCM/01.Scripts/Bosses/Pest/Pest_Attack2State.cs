using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Pest_Attack2State : BossState
{
    private Vector3[] LaserPos = new Vector3[12];
    
    public Pest_Attack2State(Pest pest) : base(pest){
    }

    protected override void EnterState()
    {
        base.EnterState();
        InitLaser();

        _pest.StartCoroutine(LaserAttackCoroutine());
    }

    public override void UpdateState()
    {
        
        base.UpdateState();
    }
    
    public IEnumerator LaserAttackCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            ShowLaserRoute();
            _pest.LineRenderer.startWidth = 0.2f;
            _pest.LineRenderer.endWidth = 0.2f;
            _pest.LineRenderer.startColor = new Color(1f, 0f, 0f, 1);
            _pest.LineRenderer.endColor = new Color(1f, 0f, 0f, 1);
            yield return new WaitForSeconds(1f);
            _pest.LaserCollider.gameObject.SetActive(true);
            _pest.LineRenderer.startWidth = 1.4f;
            _pest.LineRenderer.endWidth = 2f;
            _pest.LineRenderer.startColor = new Color(1f, 1f, 1f, 1);
            _pest.LineRenderer.endColor = new Color(1f, 1f, 1f, 1);
            yield return new WaitForSeconds(1.2f);
            _pest.LaserCollider.gameObject.SetActive(false);
            _pest.LineRenderer.startColor = new Color(1f, 1f, 1f, 0);
            _pest.LineRenderer.endColor = new Color(1f, 1f, 1f, 0);
            _pest.transform.DORotate(new Vector3(_pest.transform.eulerAngles.x
                , _pest.transform.eulerAngles.y, _pest.transform.eulerAngles.z+UnityEngine.Random.Range(40,20)), 0.8f);
            yield return new WaitForSeconds(0.8f);
        }
        _pest.transform.rotation = Quaternion.Euler(0,0,0);
        _pest.TransitionState(BossStateType.Idle);
    }
    
    private void ShowLaserRoute()
    {
        for (int j = 0; j <= 10; j+=2)
        {
            _pest.LineRenderer.SetPosition(j,Vector3.zero);
            _pest.LineRenderer.SetPosition(j +1,_pest.lines[j/2].position);
        }
    }

    private void InitLaser()
    {
        for (int i = 0; i < 11; i += 2)
        {
            LaserPos[i] = Vector3.zero;
        }

        for (int i = 1; i <= 11; i += 2)
        {
            LaserPos[i - 1] = _pest.lines[i / 2].position;
        }
    }
    
    

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    protected override void ExitState()
    {
        base.ExitState();
    }
}
