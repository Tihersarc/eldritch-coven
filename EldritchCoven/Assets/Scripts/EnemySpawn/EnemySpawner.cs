using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySpawnManager spawnManager;
    [SerializeField] GameObject[] props;
    [SerializeField] Enemy[] enemies;
    [SerializeField] Transform spawnPoint;
    GameObject spawnedEnemy;

    private void Start()
    {
        InstantiateHiddenEnemy();
        InstantiateProp();
    }

    private void InstantiateProp()
    {
        Instantiate(props[(int)Random.Range(0, props.Length)], this.gameObject.transform);
    }

    public void InstantiateHiddenEnemy()
    {
        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        GameObject enemy = Instantiate(enemies[(int)Random.Range(0, enemies.Length)].gameObject, this.gameObject.transform);
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = enemyRotation;
        spawnedEnemy = enemy;
    }

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        //hiddenScript.enabled = false;
        //gameObject.layer = 0;
        //stateController.enabled = true;

        HiddenObjects hiddenScript = spawnedEnemy.GetComponent<HiddenObjects>();
        //hiddenScript.enabled = true;
        hiddenScript.ShowHiddenObject();
        spawnedEnemy.GetComponent<StateController>().enabled = true;
    }

    public void RemoveSpawner()
    {
#if UNITY_EDITOR
        Undo.RegisterCompleteObjectUndo(spawnManager, "RemoveSpawner");
#endif
        spawnManager.spawners.Remove(this);
    }

    private void OnDestroy()
    {
    }
    public void SetSpawnerManager(EnemySpawnManager enemySpawnManager)
    {
#if UNITY_EDITOR
        Undo.RegisterCompleteObjectUndo(enemySpawnManager, "SetSpawnerManager");
#endif
        spawnManager = enemySpawnManager;
    }
}
