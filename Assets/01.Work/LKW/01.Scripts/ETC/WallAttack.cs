using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallAttack : MonoBehaviour
{
    public List<Transform> walls;

    public void WallWave(Transform Ground, float localPosX, Quaternion transformRotation)
    {
        transform.SetParent(Ground);
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.localPosition = new Vector3(localPosX,0,0);
        StartCoroutine(WaveCoroutine());

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
        }
    }

    private IEnumerator WaveCoroutine()
    {
        int j = 5;
        for (int i = 5; i <= 10; i++)
        {
            walls[i].DOLocalMoveY(walls[i].transform.localPosition.y + 3.4f, 1.2f)
                .SetEase(Ease.OutBounce)
                .SetLoops(2, LoopType.Yoyo);
            walls[j].DOLocalMoveY(walls[j].transform.localPosition.y + 3.4f, 1.2f)
                .SetEase(Ease.OutBounce)
                .SetLoops(2, LoopType.Yoyo);
            j--;
            yield return new WaitForSeconds(0.16f);
        }
        
    }
}
