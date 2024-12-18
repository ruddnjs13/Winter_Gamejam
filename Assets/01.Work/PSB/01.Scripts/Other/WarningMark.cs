using UnityEngine;

public class WarningMark : MonoBehaviour, IPoolable
{
    public string PoolName => "WarningMark";

    public GameObject objectPrefab => gameObject;

    public void ResetItem()
    {
    }

}
