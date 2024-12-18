using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private Transform player;

    private void Start()
    {
        CheckPlayerPosition();
    }

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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Destroy(gameObject);
            WaveManager.Instance.EnemyDefeated();
        }
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

}
