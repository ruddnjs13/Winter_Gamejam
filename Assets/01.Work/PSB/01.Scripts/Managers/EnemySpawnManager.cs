using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("EnemyPrefab")]
    [SerializeField] private GameObject meleeEnemyPrefab;
    [SerializeField] private GameObject rangedEnemyPrefab;
    [SerializeField] private GameObject bombEnemyPrefab;
    [SerializeField] private GameObject dashEnemyPrefab;
    [Space(10)]
    [Header("BossPrefab")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossPrefab2;
    [SerializeField] private GameObject bossPrefab3;
    [Space(10)]
    [Header("SpawnPoint")]
    public Transform spawnPoint;
    public Transform bossSpawnpoint;
    [Space(10)]
    [Header("List")]
    [SerializeField] private List<Transform> enemyTrans = new List<Transform>();
    [SerializeField] private List<Enemy> enemyLists = new List<Enemy>();
    [SerializeField] private List<Boss> bossLists = new List<Boss>();

    public int enemiesAlive = 0;

    public void FiveWaveMethod()
    {
        spawnPoint = bossSpawnpoint;
        enemiesAlive = 1;
    }

    public void BossSpawnFiveMethod()
    {
        Instantiate(bossPrefab, bossSpawnpoint.position, Quaternion.identity);
    }
    public void BossSpawnTenMethod()
    {
        Instantiate(bossPrefab2, bossSpawnpoint.position, Quaternion.identity);
    }
    public void BossSpawnFifteenMethod()
    {
        Instantiate(bossPrefab3, bossSpawnpoint.position, Quaternion.identity);
    }

    public void WaveSpawnMethod()
    {
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
        StartCoroutine(ShowWarningIcon(enemyName));
    }

    public void EnemyClear()
    {
        enemyLists.Clear();
        bossLists.Clear();
    }

    private IEnumerator ShowWarningIcon(string enemyName)
    {
        int randomPoint = UnityEngine.Random.Range(0, enemyTrans.Count);
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle;
        Vector2 spawnedPoint = enemyTrans[randomPoint].position + (Vector3)randomOffset;
        for (int i = 0; i < enemyTrans.Count; i++)
        {
            WarningMark mark = PoolManager.Instance.Pop("WarningMark") as WarningMark;
            mark.transform.position = spawnedPoint;
            yield return new WaitForSeconds(0.3f);
            mark.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
        Enemy enemy = PoolManager.Instance.Pop(enemyName) as Enemy;
        enemy.transform.position = spawnedPoint + randomOffset;
        enemy.transform.localScale = new Vector2(0, 0);
        enemy.transform.DOScale(1, 0.3f);
        enemyLists.Add(enemy);
    }

}
