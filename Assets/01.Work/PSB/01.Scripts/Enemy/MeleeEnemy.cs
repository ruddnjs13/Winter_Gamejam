using UnityEngine;

public class MeleeEnemy : Enemy, IPoolable
{
    public string PoolName => "MeleeEnemy";

    public GameObject objectPrefab => gameObject;


    private void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Vector2.MoveTowards(transform.position, transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    public void ResetItem()
    {
    }
}
