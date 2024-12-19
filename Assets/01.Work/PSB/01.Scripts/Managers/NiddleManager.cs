using System.Collections;
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
        StartCoroutine(ShowWarningMark());
    }

    public void NiddleClear()
    {
        foreach (IPoolable n in niddleLists)
        {
            PoolManager.Instance.Push(n);
        }
        niddleLists.Clear();
    }

    private IEnumerator ShowWarningMark()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnPoint = niddleTrans[UnityEngine.Random.Range(0, niddleTrans.Count)];
            for (int j = 0; j < niddleTrans.Count; j++)
            {
                NiddleWarningmark mark = PoolManager.Instance.Pop("NiddleWarningMark") as NiddleWarningmark;
                mark.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(0.03f);
                mark.gameObject.SetActive(false); 
            }
            yield return new WaitForSeconds(0.005f);
            Niddle spike = PoolManager.Instance.Pop("Niddle") as Niddle;
            if (spike != null)
            {
                spike.transform.position = spawnPoint.position;
                niddleLists.Add(spike);
                niddleTrans.Remove(spawnPoint);
            }
        }
        
    }


}
