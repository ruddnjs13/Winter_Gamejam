using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoSingleton<WaveManager>
{
    [Header("Manager")]
    private NiddleManager niddleManager;
    private EnemySpawnManager enemySpawnManager;
    [Space(10)]
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI waveTxt;
    [SerializeField] private TextMeshProUGUI waveCountTxt;
    private int currentWave = 0;
    

    private void Start()
    {
        waveTxt.text = "";
        StartCoroutine(WaveStartCount(3));
    }

    private void Awake()
    {
        niddleManager = GetComponentInChildren<NiddleManager>();
        enemySpawnManager = GetComponentInChildren<EnemySpawnManager>();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void StartWave()
    {
        enemySpawnManager.EnemyClear();
        niddleManager.NiddleClear();
        currentWave++;
        Debug.Log($"{currentWave} ���̺� ����");

        int numberOfEnemies = currentWave;

        if (currentWave % 2 == 0)
        {
            niddleManager.SpawnUnderSpike();
        }
        if (currentWave % 5 == 0)
        {
            waveTxt.text = $"BossWave";
            waveTxt.color = Color.red;

            enemySpawnManager.spawnPoint = enemySpawnManager.bossSpawnpoint;
            enemySpawnManager.enemiesAlive = 1;

            if (currentWave == 5)
            {
                enemySpawnManager.BossSpawnFiveMethod();
            }
            else if (currentWave == 10)
            {
                enemySpawnManager.BossSpawnTenMethod();
            }
            else if (currentWave == 15)
            {
                enemySpawnManager.BossSpawnFifteenMethod();
            }

        }
        else
        {
            StartCoroutine(SpawnCoroutine(currentWave));
        }
    }

    public void EnemyDefeated()
    {
        enemySpawnManager.enemiesAlive--;
        if (enemySpawnManager.enemiesAlive <= 0)
        {
            if (currentWave < 15)
            {
                Debug.Log($"{currentWave} ���̺� ��");
                StartCoroutine(WaveStartCount(3));
            }
            else
            {
                Debug.Log("��� ���̺갡 �Ϸ�Ǿ����ϴ�!");
            }
        }
    }

    private IEnumerator WaveStartCount(int waveCount)
    {
        waveCountTxt.gameObject.SetActive(true);

        for (int i = waveCount; i > 0; i--)
        {
            waveCountTxt.text = $"�����ð� : {i}";
            yield return new WaitForSeconds(1f);
        }

        waveCountTxt.text = "������ �����ɴϴ�!";
        yield return new WaitForSeconds(1f);

        waveCountTxt.gameObject.SetActive(false);
        StartWave();
    }

    private IEnumerator SpawnCoroutine(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            waveTxt.text = $"Wave : {currentWave}";
            waveTxt.color = Color.black;

            enemySpawnManager.WaveSpawnMethod();
            yield return new WaitForSeconds(0.1f);
        }
        enemySpawnManager.enemiesAlive = numberOfEnemies;
    }

}
