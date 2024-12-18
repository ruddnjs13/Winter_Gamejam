using UnityEngine;
using System;
using System.Collections.Generic;

public class SmallPox : Boss
{
    [field: SerializeField] public SmallPoxData SmallPoxData { get; private set; }
    
    public List<Sprite> ShieldSprite { get; private set; }
    
    public Vector3 DefaultTransform {get; private set;}

    public LayerMask _whatIsGround;
    protected override void Awake(){
        base.Awake();
        foreach (BossStateType stateType in Enum.GetValues(typeof(BossStateType)))
        {
            try
            {
                string enumName = stateType.ToString();
                Type t = Type.GetType($"SmallPox_{enumName}State");
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
        TransitionState(BossStateType.Attack1);
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
        Gizmos.DrawWireSphere(transform.position, SmallPoxData.checkGroundRadius);
    }
}
