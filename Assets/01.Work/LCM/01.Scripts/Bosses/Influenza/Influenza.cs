using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class Influenza : Boss
{
    [field: SerializeField] public InfluenzaData InfluenzaData { get; private set; }
    [field: SerializeField] public LayerMask _whatIsGround { get; private set; }
    public Vector3 DefaultTransform {get; private set;}

    public List<GameObject> shields;

    public UnityEvent OnDead;
    
    [SerializeField] private ParticleSystem _particle;

    public bool IsCanDie{ get; set; } = false;

    private BossStateType _currentState;
    
    protected override void Awake(){
        base.Awake();
        foreach (BossStateType stateType in Enum.GetValues(typeof(BossStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"Influenza_{enumName}State");
                BossState state = Activator.CreateInstance(t, new object[]{ this }) as BossState;
                StateEnum.Add(stateType, state);
            }
            catch
            {
                // ignored
            }
        }
        DefaultTransform = transform.position;
    }

    private void Start(){
        TransitionState(BossStateType.Attack2);
    }

    public void RandomAttack(){
        int rand  = UnityEngine.Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                if (_currentState == BossStateType.Attack1)
                {
                    Debug.Log("다시 뽑음");
                    RandomAttack();
                    break;
                }

                _currentState = BossStateType.Attack1;
                TransitionState(BossStateType.Attack1);
                break;
            case 2:
                if (_currentState == BossStateType.Attack2)
                {
                    Debug.Log("다시 뽑음");
                    RandomAttack();
                    break;
                }
                _currentState = BossStateType.Attack2;
                TransitionState(BossStateType.Attack2);
                break;
            case 3:
                if (_currentState == BossStateType.Attack3)
                {
                    Debug.Log("다시 뽑음");
                    RandomAttack();
                    break;
                }
                _currentState = BossStateType.Attack3;
                TransitionState(BossStateType.Attack3);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Weapon") && IsCanDie)
        {
            Instantiate(_particle,transform.position,Quaternion.identity);
            OnDead?.Invoke();
            WaveManager.Instance.EnemyDefeated();
            Destroy(gameObject);
        }
    }

    public void RemoveList(GameObject shield)
    {
        shields.Remove(shield);
    }

    protected override void OnDrawGizmos(){
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InfluenzaData.checkGroundRadius);
    }
}
