using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class SmallPox : Boss
{
    [field: SerializeField] public SmallPoxData SmallPoxData { get; private set; }
    
    [field: SerializeField] public List<Sprite> ShieldSprite { get; private set; }
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public FeedbackPlayer FeedbackPlayer { get; set; }

    private int hp = 2;
    
    private BossStateType _currentState;
    
    public Vector3 DefaultTransform {get; private set;}

    public LayerMask _whatIsGround;
    
    public Vector2 TargetingPlayer{ get; set; }

    public int Count{ get; private set; }
    public bool CheckStart{ get; set; }
    public bool IsCanDie{ get; set; } = false;
    
    public UnityEvent OnDeath;
    private static bool _isCanHit;
    private float _curTime;
    private float _maxTime = 1f;
    
    [SerializeField] private ParticleSystem _particleSystem;
    
    [field:SerializeField] public ParticleSystem _collisionParticle{ get; private set; }
    
    private static int _bossCount = 2;
    [field: SerializeField] public int BoundCount{ get; private set; }
    protected override void Awake(){
        base.Awake();
        FeedbackPlayer = GetComponent<FeedbackPlayer>();
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

    private void LateUpdate(){
        _curTime += Time.deltaTime;
        if (_curTime >= _maxTime)
        {
            _isCanHit = true;
        }
        
        Debug.Log(_bossCount);
    }

    public void RandomAttack(){
        int rand  = UnityEngine.Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                if (_currentState == BossStateType.Attack1)
                {
                    RandomAttack();
                    break;
                }

                _currentState = BossStateType.Attack1;
                TransitionState(BossStateType.Attack1);
                break;
            case 2:
                if (_currentState == BossStateType.Attack2)
                {
                    RandomAttack();
                    break;
                }
                _currentState = BossStateType.Attack2;
                TransitionState(BossStateType.Attack2);
                break;
            case 3:
                if (_currentState == BossStateType.Attack3)
                {
                    RandomAttack();
                    break;
                }
                _currentState = BossStateType.Attack3;
                TransitionState(BossStateType.Attack3);
                break;
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground"))
        {
            FeedbackPlayer.PlayFeedbacks();
            Collider2D collider2D = Physics2D.OverlapCircle(transform.position,
                SmallPoxData.checkGroundRadius, _whatIsGround);

            Vector2 pos = collider2D.ClosestPoint(transform.position);
            
            InstatiateCollisionParticle(pos);
            
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
                Instantiate(_particleSystem, transform.position, Quaternion.identity);
                OnDeath?.Invoke();
                _bossCount--;
                if (_bossCount == 0)
                {
                    Debug.Log("다음 스테이지");
                    WaveManager.Instance.EnemyDefeated();
                }
                Destroy(gameObject);
                return;
            }
            if (hp >= 0 && _isCanHit)
            {
                hp--;
                _isCanHit = false;
                _curTime = 0f;
                if (hp < 0)
                {
                    Destroy(_spriteRenderer.gameObject);
                    TransitionState(BossStateType.Groggy);
                    return;
                }
                _spriteRenderer.sprite = ShieldSprite[hp];
            }
        }
    }
    
    public void InstatiateCollisionParticle(Vector2 pos){
        Instantiate(_collisionParticle,pos,Quaternion.identity);
    }

    protected override void OnDrawGizmos(){
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SmallPoxData.checkGroundRadius);
    }
}
