using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class SmallPox : Boss
{
    [field: SerializeField] public SmallPoxData SmallPoxData { get; private set; }
    
    [field: SerializeField] public List<Sprite> ShieldSprite { get; private set; }
    
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int hp = 2;
    
    public Vector3 DefaultTransform {get; private set;}

    public LayerMask _whatIsGround;
    
    public Vector2 TargetingPlayer{ get; set; }

    public int Count{ get; private set; }
    public bool CheckStart{ get; set; }
    public bool IsCanDie{ get; set; } = false;
    
    public UnityEvent OnDeath;
    [field: SerializeField] public int BoundCount{ get; private set; }
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
        TargetingPlayer = GetPlayerPosition().position - transform.position;
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

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("닿음");
            TargetingPlayer = GetPlayerPosition().position - transform.position;
            TargetingPlayer.Normalize();
            Count++;
            RbCompo.linearVelocity = Vector2.zero;
            if(Count >= BoundCount)
                Count = 0;
            CheckStart = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (IsCanDie)
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
                return;
            }
            if (hp <= 0)
            {
                Destroy(_spriteRenderer.gameObject);
                TransitionState(BossStateType.Groggy);
                return;
            }

            hp--;
            _spriteRenderer.sprite = ShieldSprite[hp];
            Debug.Log(hp);
        }
    }

    protected override void OnDrawGizmos(){
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SmallPoxData.checkGroundRadius);
    }
}
