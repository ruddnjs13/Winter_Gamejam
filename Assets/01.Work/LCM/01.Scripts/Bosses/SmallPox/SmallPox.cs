using UnityEngine;
using System;

public class SmallPox : Boss
{
    [field: SerializeField] public SmallPoxData SmallPoxData { get; private set; }
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
    }

    private void Start(){
        TransitionState(BossStateType.Idle);
    }
}
