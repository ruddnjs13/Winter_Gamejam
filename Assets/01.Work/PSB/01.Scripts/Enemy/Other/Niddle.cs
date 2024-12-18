using UnityEngine;

public class Niddle : MonoBehaviour, IPoolable
{
    public string PoolName => "Niddle";

    public GameObject objectPrefab => gameObject;

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PoolManager.Instance.Push(this);
        }*/
    }

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
