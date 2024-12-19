using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IPoolable
{
    public string PoolName => "EnemyProjectile";

    public GameObject objectPrefab => gameObject;

    private void Update()
    {
        if (transform.position.magnitude > 10f)
        {
            Destroy(gameObject);
        }
    }

    public void ResetItem()
    {
    }


}
