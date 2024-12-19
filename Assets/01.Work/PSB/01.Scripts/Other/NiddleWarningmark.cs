using UnityEngine;

public class NiddleWarningmark : MonoBehaviour, IPoolable
{
    public string PoolName => "NiddleWarningMark";

    public GameObject objectPrefab => gameObject;

    public void ResetItem()
    {
    }

}
