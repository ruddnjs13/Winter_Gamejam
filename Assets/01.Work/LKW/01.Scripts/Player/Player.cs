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

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerRenderer = transform.Find("Visual").GetComponent<PlayerRenderer>();
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        _playerRenderer.Flip(_inputReader.MoveX);
        _playerMove.SetVelocity(_inputReader.MoveX * _moveSpeed);
        _playerRenderer.SetMoveXHash(Mathf.Abs(_inputReader.MoveX));
    }
}
