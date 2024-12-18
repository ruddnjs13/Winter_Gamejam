using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1f;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(gameObject);
            WaveManager.Instance.EnemyDefeated();
        }

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
}
