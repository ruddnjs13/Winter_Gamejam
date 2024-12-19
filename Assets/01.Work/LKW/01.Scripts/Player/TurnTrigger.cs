using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private bool _isVertical;
    public bool _isReverse;

    private bool _canTurn = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _whatIsPlayer) != 0)
        {
            PlayerTurn(collision);
        }
    }

    private void PlayerTurn(Collider2D collision)
    {
        if (!_canTurn) return;

        StartCoroutine(TurnDelayCoroutine());
        GameObject playerObj = collision.gameObject;
        Player player = playerObj.GetComponent<Player>();
        player.isVerticalMove = _isVertical;
        player.isReverseMove = _isReverse;
        playerObj.transform.SetParent(transform.parent);
        playerObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        playerObj.transform.localPosition = new Vector3(playerObj.transform.localPosition.x
            , 0.94f, playerObj.transform.localPosition.z);
    }

    private IEnumerator DelayAndTurn()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private IEnumerator TurnDelayCoroutine()
    {
        _canTurn = false;
        yield return new WaitForSeconds(0.2f);
        _canTurn = true;
    }
}