using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask _whatIsGround;
    private Player _player;

    [SerializeField] private float _coolTime = 5f;
    private bool _isCool = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    public void SetVelocity(float move , bool isYMove = false)
    {
        _rigidbody.linearVelocity =transform.right * move;
    }

    public void ReversePos()
    {
        if (_isCool) return;
        StartCoroutine(CoolTimeCoroutine());
        RaycastHit2D hit = Physics2D.Raycast(transform.position
            , transform.up, Mathf.Infinity, _whatIsGround);
        if (hit.collider != null)
        {
            transform.SetParent(hit.collider.transform);
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localPosition = new Vector3(transform.localPosition.x, 0.94f, transform.localPosition.z);
            _player.isReverseMove = hit.collider.GetComponentInChildren<TurnTrigger>()._isReverse;
        }
    }

    public void Stop()
    {
        _rigidbody.linearVelocity = Vector2.zero;
    }

    private IEnumerator CoolTimeCoroutine()
    {
        _isCool = true;
        yield return new WaitForSeconds(_coolTime);
        _isCool = false;
        
    }
}
