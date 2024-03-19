using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private static EnemySpawnManager enemySpawnManager;

    public static EnemySpawnManager instance
    {
        get
        {
            return RequestInstance();
        }
    }

    static EnemySpawnManager RequestInstance()
    {

        if (enemySpawnManager == null)
        {
            enemySpawnManager = FindObjectOfType<EnemySpawnManager>();

            if (enemySpawnManager == null)
            {
                GameObject enemySpawnObject = new GameObject("EnemySpawnManager");
                enemySpawnManager = enemySpawnObject.AddComponent<EnemySpawnManager>();
            }
        }
        return enemySpawnManager;
    }

    public List<EnemySpawner> spawners = new List<EnemySpawner>();
    [SerializeField] int spawnTime;
    float currentTimeToSpawn;


    void Start()
    {
        currentTimeToSpawn = 0f;
    }

    void Update()
    {
        if( currentTimeToSpawn > spawnTime )
        {
            EnemySpawner enemy = spawners[Random.Range(0, spawners.Count)];
            enemy.Spawn();
            currentTimeToSpawn = 0f;
        }
        else
        {
            currentTimeToSpawn += Time.deltaTime;
        }
    }
}
