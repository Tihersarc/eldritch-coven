using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySpawnManager spawnManager;
    [SerializeField] Mesh[] propsMeshes;
    [SerializeField] Enemy[] enemies;
    [SerializeField] Transform spawnPoint;
    GameObject spawnedEnemy;

    private void Start()
    {
        InstantiateEnemy();
    }

    public void InstantiateEnemy()
    {
        this.GetComponent<MeshFilter>().mesh = propsMeshes[(int)Random.Range(0, propsMeshes.Length)];

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
        hiddenScript.enabled = true;
        hiddenScript.ShowHiddenObject();
        spawnedEnemy.GetComponent<StateController>().enabled = true;
    }

    //private void OnEnable()
    //{
    //    EnemySpawnManager.instance.spawners.Add(this);
    //}


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
