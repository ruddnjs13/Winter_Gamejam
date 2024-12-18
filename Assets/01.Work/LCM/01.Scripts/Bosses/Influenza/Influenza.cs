using UnityEngine;
using System;

public class Influenza : Boss
{
    [field: SerializeField] public InfluenzaData InfluenzaData { get; private set; }
    [field: SerializeField] public LayerMask _whatIsGround { get; private set; }
    [field: SerializeField] public Transform DefaultTransform {get; private set;}
    
    
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
    }

    private void Start(){
        TransitionState(BossStateType.Attack2);
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

    protected override void OnDrawGizmos(){
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InfluenzaData.checkGroundRadius);
    }
}
