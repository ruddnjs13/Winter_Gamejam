using UnityEngine;

public class Niddle : MonoBehaviour, IPoolable
{
    public string PoolName => "Niddle";

    public GameObject objectPrefab => gameObject;

    public void ResetItem()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
