using UnityEngine;

public class RangedEnemy : Enemy, IPoolable
{
    public GameObject projectilePrefab;
    public float shootRange = 5f;
    public float chaseRange = 10f;
    public float shootInterval = 2f;
    private float lastShotTime;

    public string PoolName => "RangedEnemy";

    public GameObject objectPrefab => gameObject;

    private void Start()
    {
        lastShotTime = Time.time;
    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance < shootRange && Time.time > lastShotTime + shootInterval)
            {
                Shoot();
                lastShotTime = Time.time;
            }
            else if (distance < chaseRange)
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position, 3f * Time.deltaTime);
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

    private void Shoot()
    {
        EnemyProjectile bullet = PoolManager.Instance.Pop("EnemyProjectile") as EnemyProjectile;
        bullet.transform.position = transform.position;
        Vector2 direction = (player.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;
    }

    private void MoveTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) >= shootRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);
        }
    }

    public void ResetItem()
    {
    }

}
