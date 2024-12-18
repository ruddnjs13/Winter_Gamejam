using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.magnitude > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
