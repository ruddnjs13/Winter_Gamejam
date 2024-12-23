using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaponArm : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _firePos;
    private SpriteRenderer _spriteRenderer;
    
    private ReloadUI _reloadUI;

    private Player _player;

    public UnityEvent shootEvent;
    
    public float currentAngle {get; private set;}
    

    private float _attackCooldown = 4f;
    private bool _canAttack = true;

    private void Awake()
    {
        _spriteRenderer = transform.Find("Gun").GetComponent<SpriteRenderer>();
        _player = GetComponentInParent<Player>();
        _reloadUI = transform.parent.GetComponentInChildren<ReloadUI>();
    }

    private void Start()
    {
        _reloadUI.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _inputReader.AttackEvent += HandleAttackEvent;
    }

    private void OnDisable()
    {
        _inputReader.AttackEvent -= HandleAttackEvent;
    }

    private void HandleAttackEvent()
    {
        if(!_canAttack) return;
        _reloadUI.gameObject.SetActive(true);
        StartCoroutine(ReloadCoroutine());
        shootEvent?.Invoke();
        Bullet bullet =  PoolManager.Instance.Pop("Bullet") as Bullet;

        Vector3 dir = ((Vector3)_inputReader.MousePos - transform.position).normalized;

        bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
        
        Vector3 bulletPos = _firePos.position;

        if (_player.isReverseMove)
            bulletPos = transform.TransformPoint(_firePos.localPosition - new Vector3(0,1,0));
        bullet.transform.position = bulletPos;
        bullet.SetVelocity(dir*10);
    }

    private  IEnumerator ReloadCoroutine()
    {
        _canAttack = false;
        float currentValue = 0.1f;
        while (currentValue <= 1.6f)
        {
            currentValue += Time.deltaTime;
            _reloadUI.SetValue(currentValue);
            yield return null;
        }
        _reloadUI.gameObject.SetActive(false);
        _canAttack = true;
    }

    private void Update()
    {
        _reloadUI.Flip(transform.parent.localScale.x >= 0);
        RotateGun();
    }

    private void FlipWeapon(float angle)
    {
        _spriteRenderer.flipY = (angle  >90? true : false) || angle < -90? true : false;
    }

    private void RotateGun()
    {
        Vector3 mousePos = _inputReader.MousePos;
        Vector2 direction = transform.parent.InverseTransformPoint(mousePos).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        currentAngle = angle;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
        FlipWeapon(angle);
    }
    
    
}
