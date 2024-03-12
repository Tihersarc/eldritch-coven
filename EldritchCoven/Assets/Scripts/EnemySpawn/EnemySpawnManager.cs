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

    public List<EnemySpawnData> spawners = new List<EnemySpawnData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
