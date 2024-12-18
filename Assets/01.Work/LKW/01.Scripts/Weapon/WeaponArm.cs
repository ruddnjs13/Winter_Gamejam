using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponArm : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _firePos;
    private SpriteRenderer _spriteRenderer;
    

    private float _attackCooldown = 4f;
    private bool _canAttack = true;

    private void Awake()
    {
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
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
        StartCoroutine(AttackCoolCoroutine());
        Bullet bullet =  PoolManager.Instance.Pop("Bullet") as Bullet;
        bullet.transform.position = _firePos.position;
        bullet.transform.rotation = transform.rotation;
    }

    private  IEnumerator AttackCoolCoroutine()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }

    private void Update()
    {
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
        transform.localRotation = Quaternion.Euler(0, 0, angle);
        FlipWeapon(angle);
    }
    
    
}
