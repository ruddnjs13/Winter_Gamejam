using UnityEngine;

public class BombEnemy : Enemy, IPoolable
{
    private Vector3 targetPosition;
    private bool isMoving = false;

    public string PoolName => "BombEnemy";

    public GameObject objectPrefab => gameObject;

    private void Start()
    {
        CheckPlayerPosition();
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    private void CheckPlayerPosition()
    {
        targetPosition = player.position;
        isMoving = true;
    }

    public void ResetItem()
    {
    }


}
