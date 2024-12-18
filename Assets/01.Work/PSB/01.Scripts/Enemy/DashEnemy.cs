using System.Collections;
using UnityEngine;

public class DashEnemy : Enemy, IPoolable
{
    public float dashDistance = 5f;
    public float dashCooldown = 3f;
    public float dashDuration = 0.2f;

    private float lastDashTime = 0f;
    private bool isDashing = false;

    public string PoolName => "DashEnemy";

    public GameObject objectPrefab => gameObject;

    private void Update()
    {
        if (player != null)
        {
            if (!isDashing)
            {
                MoveTowardsPlayer();

                if (Time.time - lastDashTime > dashCooldown)
                {
                    StartCoroutine(Dash());
                }
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        Vector2 dashDirection = (player.position - transform.position).normalized;
        float dashTime = 0f;

        while (dashTime < dashDuration)
        {
            transform.position += (Vector3)(dashDirection * (dashDistance / dashDuration) * Time.deltaTime);
            dashTime += Time.deltaTime;
            yield return null;
        }

        lastDashTime = Time.time;
        isDashing = false;
    }

    public void ResetItem()
    {
    }


}
