using System;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerTurn();
    }

    private void PlayerTurn()
    {
    }
}
