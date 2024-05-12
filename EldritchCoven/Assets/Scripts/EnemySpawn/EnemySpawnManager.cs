using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemySpawnerPrefab;
    private static EnemySpawnManager enemySpawnManager;

    public static EnemySpawnManager instance
    {
        get
        {
            return RequestInstance();
        }
        private set { }
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
    [SerializeField] int spawnTime = 300;
    [SerializeField] int[] spawnDelayRange = new int[2] {120, 300};
    int spawnDelay;
    float currentTimeToSpawn;
    float currentTimeToSpawnDelay;
    bool canSpawn = false;
    bool beginToSpawn = false;

    private void Awake()
    {
        instance = this.GetComponent<EnemySpawnManager>();
        PlayerEnterTrigger.OnEnter += () => { canSpawn = true; };
    }

    void Start()
    {
        currentTimeToSpawn = 0f;
        currentTimeToSpawnDelay = 0f;
        spawnDelay = Random.Range(spawnDelayRange[0], spawnDelayRange[1]);
    }

    void Update()
    {
        if (canSpawn && spawners.Count > 0)
        {
            if (!beginToSpawn)
            {
                if (currentTimeToSpawn > spawnTime)
                {
                    int randomIndex = Random.Range(0, spawners.Count);
                    EnemySpawner enemy = spawners[randomIndex];
                    enemy.Spawn();
                    spawners.RemoveAt(randomIndex);
                    beginToSpawn = true;
                }
                else
                {
                    currentTimeToSpawn += Time.deltaTime;
                }
            }
            else
            {
                if (currentTimeToSpawnDelay > spawnDelay)
                {
                    int randomIndex = Random.Range(0, spawners.Count);
                    EnemySpawner enemy = spawners[randomIndex];
                    enemy.Spawn();
                    spawners.RemoveAt(randomIndex);
                    spawnDelay = Random.Range(spawnDelayRange[0], spawnDelayRange[1]);
                    currentTimeToSpawnDelay = 0f;
                }
                else
                {
                    currentTimeToSpawnDelay += Time.deltaTime;
                }
            }
        }
    }

    public GameObject GetSpawnerPrefab()
    {
        return enemySpawnerPrefab;
    }
}
