using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("PlayerSetting")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    private PlayerMove _playerMove;
    private PlayerRenderer _playerRenderer;
    [SerializeField] private InputReader _inputReader;

    public bool isVerticalMove { get; set; } = false;
    public bool isReverseMove { get; set; } = false;
    
    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerRenderer = transform.Find("Visual").GetComponent<PlayerRenderer>();
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
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle")|| collision.CompareTag("Boss"))
        {
            Time.timeScale = 0;
        }
    }
}
