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
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform bossSpawnpoint;
    [Space(10)]
    [Header("List")]
    [SerializeField] private List<Transform> enemyTrans = new List<Transform>();
    [SerializeField] private List<Enemy> enemyLists = new List<Enemy>();

    public int enemiesAlive = 0;

    public void FiveWaveMethod()
    {
        spawnPoint = bossSpawnpoint;
        enemiesAlive = 1;
    }

    public void FiveDrainageMethod(GameObject prefab)
    {
        //Boss
        //PoolManager.Instance.Pop(prefab);
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
        int randomPoint = UnityEngine.Random.Range(0, enemyTrans.Count);
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle;
        Vector2 spawnedPoint = enemyTrans[randomPoint].position + (Vector3)randomOffset;
        //spawnPoint = trans[UnityEngine.Random.Range(0, trans.Count)];
        Enemy enemy = PoolManager.Instance.Pop(enemyName) as Enemy;
        enemy.transform.position = spawnedPoint + randomOffset;
        enemyLists.Add(enemy);
    }

    public void EnemyClear()
    {
        enemyLists.Clear();
    }

}
