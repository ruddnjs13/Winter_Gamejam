using System.Collections.Generic;
using UnityEngine;

public class NiddleManager : MonoSingleton<NiddleManager>
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject niddlePrefab;
    [SerializeField] private List<Transform> niddleTrans = new List<Transform>();
    [SerializeField] private List<Niddle> niddleLists = new List<Niddle>();

    public void SpawnUnderSpike()
    {
        //Enemy처럼 표시하고 생성하기
        for (int i = 0; i < 3; i++)
        {
            Niddle spike = PoolManager.Instance.Pop("Niddle") as Niddle;
            if (spike != null)
            {
                spawnPoint = niddleTrans[UnityEngine.Random.Range(0, niddleTrans.Count)];
                spike.transform.position = spawnPoint.position;
                niddleLists.Add(spike);
                niddleTrans.Remove(spawnPoint);
            }
        }
    }

    public void NiddleClear()
    {
        foreach (IPoolable n in niddleLists)
        {
            PoolManager.Instance.Push(n);
        }
        niddleLists.Clear();
    }

}
