using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class WaveManager : MonoSingleton<WaveManager>
{
    [Header("Value")]

    [Header("EnemyPrefab")]
    [SerializeField] private GameObject meleeEnemyPrefab;
    [SerializeField] private GameObject rangedEnemyPrefab;
    [SerializeField] private GameObject bombEnemyPrefab;
    [SerializeField] private GameObject dashEnemyPrefab;
    [SerializeField] private GameObject testObj;
    [Space(10)]
    [Header("BossPrefab")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossPrefab2;
    [SerializeField] private GameObject bossPrefab3;
    [Space(10)]
    [Header("SpawnPoint")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform bossSpawnpoint;
    [Space(10)]
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI waveTxt;
    [SerializeField] private TextMeshProUGUI waveCountTxt;
    [Space(10)]
    [Header("List")]
    [SerializeField] private List<Transform> trans = new List<Transform>();

    private int currentWave = 0;
    private int enemiesAlive = 0;

    private void Start()
    {
        waveTxt.text = "";
        StartCoroutine(WaveStartCount(3));
    }

    private void StartWave()
    {
        currentWave++;
        Debug.Log($"{currentWave} 웨이브 시작");

        int numberOfEnemies = currentWave;

        if (currentWave % 2 == 0)
        {
            PoolManager.Instance.Pop("Niddle");
        }
        if (currentWave % 5 == 0)
        {
            spawnPoint = bossSpawnpoint;
            waveTxt.text = $"BossWave";
            waveTxt.color = Color.red;

            if (currentWave == 5)
            {
                Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
            }
            else if (currentWave == 10)
            {
                Instantiate(bossPrefab2, spawnPoint.position, Quaternion.identity);
            }
            else if (currentWave == 15)
            {
                Instantiate(bossPrefab3, spawnPoint.position, Quaternion.identity);
            }
            enemiesAlive = 1;
        }
        else
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                waveTxt.text = $"Wave : {currentWave}";
                waveTxt.color = Color.white;

                GameObject enemyToSpawn;
                string enemyName;
                int enemyType = UnityEngine.Random.Range(0, 4);

                switch (enemyType)
                {
                    case 0:
                        enemyToSpawn = meleeEnemyPrefab;
                        enemyName = "MeleeEnemy";
                        break;
                    case 1:
                        enemyToSpawn = rangedEnemyPrefab;
                        enemyName = "RangedEnemy";
                        break;
                    case 2:
                        enemyToSpawn = bombEnemyPrefab;
                        enemyName = "BombEnemy";
                        break;
                    case 3:
                        enemyToSpawn = dashEnemyPrefab;
                        enemyName = "DashEnemy";
                        break;
                    default:
                        enemyToSpawn = meleeEnemyPrefab;
                        enemyName = "MeleeEnemy";
                        break;
                }
                spawnPoint = trans[UnityEngine.Random.Range(0, trans.Count)];
                Enemy enemy = PoolManager.Instance.Pop(enemyName) as Enemy;
                enemy.transform.position = spawnPoint.position;
            }
            enemiesAlive = numberOfEnemies;
        }
    }

    public void EnemyDefeated()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            if (currentWave < 15)
            {
                Debug.Log($"{currentWave} 웨이브 끝");
                StartCoroutine(WaveStartCount(3));
            }
            else
            {
                Debug.Log("모든 웨이브가 완료되었습니다!");
            }
        }
    }

    private IEnumerator WaveStartCount(int waveCount)
    {
        waveCountTxt.gameObject.SetActive(true);

        for (int i = waveCount; i > 0; i--)
        {
            waveCountTxt.text = $"남은시간 : {i}";
            yield return new WaitForSeconds(1f);
        }

        waveCountTxt.text = "Start!";
        yield return new WaitForSeconds(1f);

        waveCountTxt.gameObject.SetActive(false);
        StartWave();
    }

}
