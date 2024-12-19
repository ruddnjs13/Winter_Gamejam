using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Pest : Boss{
    
    public LineRenderer LineRenderer{get; private set;}
    [field: SerializeField] public PestData PestData{ get; private set; }
    [field: SerializeField] public GameObject RotationObject{ get; private set; }
    [field: SerializeField] public GameObject LaserCollider{ get; private set; }
    
    public List<GameObject> shields;
    
    public List<Transform> lines;


    public UnityEvent OnDead;

    [SerializeField] private ParticleSystem _particle;
    public bool IsCanDie{ get; set; } = false;

    protected override void Awake(){
        base.Awake();
        LineRenderer = GetComponent<LineRenderer>();
        foreach (BossStateType stateType in Enum.GetValues(typeof(BossStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"Pest_{enumName}State");
                BossState state = Activator.CreateInstance(t, new object[]{ this }) as BossState;
                StateEnum.Add(stateType, state);
            }
            catch
            {
                // ignored
            }
        }
    }

    private void Start(){
        TransitionState(BossStateType.Attack2);

    }

    public void RandomAttack(){
        int rand = UnityEngine.Random.Range(1, 4);
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
            case 4:
                TransitionState(BossStateType.Attack4);
                break;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Weapon") && IsCanDie)
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
            OnDead?.Invoke();
            Destroy(gameObject);
        }
    }
    
    public void RemoveList(GameObject shield)
    {
        shields.Remove(shield);
    }
    
    
}