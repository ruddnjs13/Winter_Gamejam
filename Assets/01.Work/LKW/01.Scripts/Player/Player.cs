using System;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("PlayerSetting")]
    [SerializeField] private float _moveSpeed = 4f;

    private WeaponArm _weaponArm;
    
    
    private PlayerMove _playerMove;
    private PlayerRenderer _playerRenderer;
    [SerializeField] private InputReader _inputReader;
    
    private bool isDead = false;
    
    public bool isVerticalMove { get; set; } = false;
    public bool isReverseMove { get; set; } = false;

    public UnityEvent DeadEvent;
    
    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerRenderer = transform.Find("Visual").GetComponent<PlayerRenderer>();
        _weaponArm = GetComponentInChildren<WeaponArm>();
    }

    private void OnEnable()
    {
        _inputReader.ReversePosEvent += HandleReversePos;
    }

    private void OnDisable()
    {
        _inputReader.ReversePosEvent -= HandleReversePos;
    }

    private void HandleReversePos()
    {
        _playerMove.ReversePos();
    }


    private void Update()
    {
        if(isDead) return;
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (isVerticalMove)
        {
            _playerRenderer.Flip(transform.position.y < _inputReader.MousePos.y);

            if (isReverseMove)
            {
                _playerMove.SetVelocity(-_inputReader.MoveDir.y * _moveSpeed);
                _playerRenderer.SetMoveXHash(Mathf.Abs(_inputReader.MoveDir.y));
            }
            else
            {
                _playerMove.SetVelocity(_inputReader.MoveDir.y * _moveSpeed);
                _playerRenderer.SetMoveXHash(Mathf.Abs(_inputReader.MoveDir.y));
            }
        }
        else
        {
            _playerRenderer.Flip(transform.position.x < _inputReader.MousePos.x);

            if (isReverseMove)
            {
                _playerMove.SetVelocity(-_inputReader.MoveDir.x * _moveSpeed);
                _playerRenderer.SetMoveXHash(Mathf.Abs(_inputReader.MoveDir.x));
            }
            else
            {
                _playerMove.SetVelocity(_inputReader.MoveDir.x * _moveSpeed);
                _playerRenderer.SetMoveXHash(Mathf.Abs(_inputReader.MoveDir.x));
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        /*if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle")|| collision.CompareTag("Boss") || collision.CompareTag("Projectile"))
        {
            _playerMove.Stop();
            isDead = true;
            _weaponArm.gameObject.SetActive(false);
            _playerRenderer.SetDead();
            _inputReader.ReversePosEvent -= HandleReversePos;
        }*/
    }
    
    

    
}
