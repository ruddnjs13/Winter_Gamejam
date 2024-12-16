using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

[CreateAssetMenu(menuName = "SO/Pool/List")]
public class PoolListSO : ScriptableObject
{
    public List<PoolItemSO> List;
}
