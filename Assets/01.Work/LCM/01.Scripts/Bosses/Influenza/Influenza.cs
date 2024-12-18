using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class Influenza : Boss
{
    [field: SerializeField] public InfluenzaData InfluenzaData { get; private set; }
    [field: SerializeField] public LayerMask _whatIsGround { get; private set; }
    public Vector3 DefaultTransform {get; private set;}

    [SerializeField] private List<GameObject> _shields;

    public UnityEvent OnDead;
    
    
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
        Debug.Log(DefaultTransform);
    }

    private void Start(){
        TransitionState(BossStateType.Idle);
    }

    public void RandomAttack(){
        int rand  = UnityEngine.Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                TransitionState(BossStateType.Attack1);
                break;
            case 2:
                TransitionState(BossStateType.Attack2);
                break;
            case 3:
                TransitionState(BossStateType.Attack3);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Weapon") && _shields.Count == 0)
        {
            OnDead?.Invoke();
            Destroy(gameObject);
        }
    }

    public void RemoveList(GameObject shield)
    {
        _shields.Remove(shield);
    }

    protected override void OnDrawGizmos(){
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InfluenzaData.checkGroundRadius);
    }
}
