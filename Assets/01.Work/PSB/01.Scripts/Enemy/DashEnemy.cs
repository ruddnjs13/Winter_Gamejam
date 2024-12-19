using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DashEnemy : Enemy, IPoolable
{
    public float dashDistance = 3f;
    public float dashCooldown = 5f;
    public float dashDuration = 6f;

    private float lastDashTime = 0f;
    private bool isDashing;

    public string PoolName => "DashEnemy";
    public GameObject objectPrefab => gameObject;

    private void Start()
    {
        isDashing = true;
        isDashing = false;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            DOTween.KillAll();
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            PoolManager.Instance.Push(this);
            WaveManager.Instance.EnemyDefeated();
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
        Vector2 targetPosition = (Vector2)transform.position + dashDirection * dashDistance;

        transform.DOMove(targetPosition, 3f)
            .SetEase(Ease.OutCubic);

        yield return new WaitForSeconds(dashCooldown);

        lastDashTime = Time.time;
        isDashing = false;
    }

    public void ResetItem()
    {
    }


}
