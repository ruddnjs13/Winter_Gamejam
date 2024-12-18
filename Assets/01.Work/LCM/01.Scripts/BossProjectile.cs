using UnityEngine;

public class BossProjectile : MonoBehaviour, IPoolable
{
    public string PoolName{ get; }
    public GameObject objectPrefab{ get; }
    public void ResetItem(){
        
    }
}
