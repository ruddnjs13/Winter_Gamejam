using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityEvent OnStartBossWave;
    public UnityEvent OnClear;
    

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
        Debug.Log($"{currentWave} 웨이브 시작");

        int numberOfEnemies = currentWave;

        if (currentWave % 2 == 0)
        {
            switch (currentWave)
            {
                case 2:
                    niddleManager.SpawnUnderSpike();
                    break;
                case 4:
                    niddleManager.SpawnUpSpike();
                    break;
                case 6:
                    niddleManager.SpawnLeftSpike();
                    break;
                case 8:
                    niddleManager.SpawnRightSpike();
                    break;
                case 12:
                    niddleManager.SpawnLeftSpike();
                    niddleManager.SpawnRightSpike();
                    break;
                case 14:
                    niddleManager.SpawnUnderSpike();
                    niddleManager.SpawnRightSpike();
                    break;
            }

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
                OnStartBossWave?.Invoke();
            }
            else if (currentWave == 10)
            {
                enemySpawnManager.BossSpawnTenMethod();
                OnStartBossWave?.Invoke();
            }
            else if (currentWave == 15)
            {
                enemySpawnManager.BossSpawnFifteenMethod();
                OnStartBossWave?.Invoke();
            }

        }
        else
        {
            switch (currentWave)
            {
                case 1:
                    StartCoroutine(SpawnCoroutine(1));
                    break;
                case 2:
                    StartCoroutine(SpawnCoroutine(1));
                    break;
                case 3: 
                    StartCoroutine(SpawnCoroutine(2));
                    break;
                case 4:
                    StartCoroutine(SpawnCoroutine(2));
                    break;
                case 6:
                    StartCoroutine(SpawnCoroutine(4));
                    break;
                case 7:
                    StartCoroutine(SpawnCoroutine(4));
                    break;
                case 8:
                    StartCoroutine(SpawnCoroutine(4));
                    break;
                case 9:
                    StartCoroutine(SpawnCoroutine(4));
                    break;
                case 11:
                    StartCoroutine(SpawnCoroutine(6));
                    break;
                case 12:
                    StartCoroutine(SpawnCoroutine(7));
                    break;
                case 13:
                    StartCoroutine(SpawnCoroutine(9));
                    break;
                case 14:
                    StartCoroutine(SpawnCoroutine(9));
                    break;
            }
        }
        

    }

    public void EnemyDefeated()
    {
        enemySpawnManager.enemiesAlive--;
        if (enemySpawnManager.enemiesAlive <= 0)
        {
            if (currentWave < 15)
            {
                Debug.Log($"{currentWave} 웨이브 끝");
                StartCoroutine(WaveStartCount(3));
            }
            else
            {
                OnClear?.Invoke();
            }
        }
    }

    private IEnumerator WaveStartCount(int waveCount)
    {
        waveCountTxt.color = Color.white;
        waveCountTxt.gameObject.SetActive(true);

        for (int i = waveCount; i > 0; i--)
        {
            waveCountTxt.text = $"남은 시간 : {i}";
            yield return new WaitForSeconds(1f);
        }

        if (currentWave == 4 || currentWave == 9 || currentWave == 14)
        {
            waveCountTxt.color = Color.red;
            waveCountTxt.text = "보스가 등장합니다..";
            yield return new WaitForSeconds(1f);
        }
        else
        {
            waveCountTxt.text = "적이 침투하고 있습니다!";
            yield return new WaitForSeconds(1f);
        }

        waveCountTxt.gameObject.SetActive(false);
        StartWave();
    }

    private IEnumerator SpawnCoroutine(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            waveTxt.color = Color.white;
            waveTxt.text = $"Wave : {currentWave}";

            enemySpawnManager.WaveSpawnMethod();
            yield return new WaitForSeconds(0.1f);
        }
        enemySpawnManager.enemiesAlive = numberOfEnemies;
    }

}
