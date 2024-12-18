using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public string PoolName { get; }
    public GameObject objectPrefab { get; }
    public void ResetItem();
}
 