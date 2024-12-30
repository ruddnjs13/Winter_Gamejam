using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiddleManager : MonoSingleton<NiddleManager>
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject niddlePrefab;
    [SerializeField] private List<Transform> underNiddleTrans = new List<Transform>();
    [SerializeField] private List<Transform> upNiddleTrans = new List<Transform>();
    [SerializeField] private List<Transform> leftNiddleTrans = new List<Transform>();
    [SerializeField] private List<Transform> rightNiddleTrans = new List<Transform>();
    [SerializeField] private List<Niddle> niddleLists = new List<Niddle>();

    public void SpawnUnderSpike()
    {
        StartCoroutine(ShowWarningMark());
    }
    public void SpawnUpSpike()
    {
        StartCoroutine(ShowWarningMarkUp());
    }
    public void SpawnLeftSpike()
    {
        StartCoroutine(ShowWarinigMarkLeft());
    }
    public void SpawnRightSpike()
    {
        StartCoroutine(ShowWarningMarkRight());
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
            spawnPoint = underNiddleTrans[UnityEngine.Random.Range(0, underNiddleTrans.Count)];
            for (int j = 0; j < underNiddleTrans.Count; j++)
            {
                NiddleWarningmark mark = PoolManager.Instance.Pop("NiddleWarningMark") as NiddleWarningmark;
                mark.transform.rotation = spawnPoint.transform.rotation;
                mark.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(0.03f);
                mark.gameObject.SetActive(false); 
            }
            yield return new WaitForSeconds(0.15f);
            Niddle spike = PoolManager.Instance.Pop("Niddle") as Niddle;
            if (spike != null)
            {
                spike.transform.rotation = spawnPoint.transform.rotation;
                spike.transform.position = spawnPoint.position;
                niddleLists.Add(spike);
                underNiddleTrans.Remove(spawnPoint);
            }
        }
    }

    private IEnumerator ShowWarningMarkUp()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnPoint = upNiddleTrans[UnityEngine.Random.Range(0, upNiddleTrans.Count)];
            for (int j = 0; j < underNiddleTrans.Count; j++)
            {
                NiddleWarningmark mark = PoolManager.Instance.Pop("NiddleWarningMark") as NiddleWarningmark;
                mark.transform.rotation = spawnPoint.transform.rotation;
                mark.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(0.03f);
                mark.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.15f);
            Niddle spike = PoolManager.Instance.Pop("Niddle") as Niddle;
            if (spike != null)
            {
                spike.transform.rotation = spawnPoint.transform.rotation;
                spike.transform.position = spawnPoint.position;
                niddleLists.Add(spike);
                upNiddleTrans.Remove(spawnPoint);
            }
        }
    }

    private IEnumerator ShowWarinigMarkLeft()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnPoint = leftNiddleTrans[UnityEngine.Random.Range(0, leftNiddleTrans.Count)];
            for (int j = 0; j < underNiddleTrans.Count; j++)
            {
                NiddleWarningmark mark = PoolManager.Instance.Pop("NiddleWarningMark") as NiddleWarningmark;
                mark.transform.rotation = spawnPoint.transform.rotation;
                mark.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(0.03f);
                mark.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.15f);
            Niddle spike = PoolManager.Instance.Pop("Niddle") as Niddle;
            if (spike != null)
            {
                spike.transform.rotation = spawnPoint.transform.rotation;
                spike.transform.position = spawnPoint.position;
                niddleLists.Add(spike);
                leftNiddleTrans.Remove(spawnPoint);
            }
        }
    }

    private IEnumerator ShowWarningMarkRight()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnPoint = rightNiddleTrans[UnityEngine.Random.Range(0, rightNiddleTrans.Count)];
            for (int j = 0; j < underNiddleTrans.Count; j++)
            {
                NiddleWarningmark mark = PoolManager.Instance.Pop("NiddleWarningMark") as NiddleWarningmark;
                mark.transform.rotation = spawnPoint.transform.rotation;
                mark.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(0.03f);
                mark.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.15f);
            Niddle spike = PoolManager.Instance.Pop("Niddle") as Niddle;
            if (spike != null)
            {
                spike.transform.rotation = spawnPoint.transform.rotation;
                spike.transform.position = spawnPoint.position;
                niddleLists.Add(spike);
               rightNiddleTrans.Remove(spawnPoint);
            }
        }
    }


}
