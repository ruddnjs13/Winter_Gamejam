using UnityEngine;

public class Niddle : MonoBehaviour, IPoolable
{
    public string PoolName => "Niddle";

    public GameObject objectPrefab => gameObject;

    public void ResetItem()
    {
    }
}
