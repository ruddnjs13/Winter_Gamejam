using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootRange = 5f;
    public float chaseRange = 10f;
    public float shootInterval = 2f;
    private Transform player;
    private float lastShotTime;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        lastShotTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(gameObject);
            WaveManager.Instance.EnemyDefeated();
        }
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

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;
    }

    private void MoveTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) >= shootRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);
        }
    }

}
