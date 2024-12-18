using System;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private bool _isVertical;
    public bool _isReverse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _whatIsPlayer) != 0)
        {
            PlayerTurn(collision);
        }
    }

    private void PlayerTurn(Collider2D collision)
    {
        GameObject playerObj = collision.gameObject;
        Player player = playerObj.GetComponent<Player>();
        player.isVerticalMove = _isVertical;
        player.isReverseMove = _isReverse;
        playerObj.transform.SetParent(transform.parent);
        playerObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        playerObj.transform.localPosition = new Vector3(playerObj.transform.localPosition.x
            , 0.94f, playerObj.transform.localPosition.z);
        
    }
}