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
    GameObject collider;
    GameObject spawnedEnemy;
    [HideInInspector] public GameObject instantiatedProp;
    [SerializeField] GameObject destroyParticles;

    private void Start()
    {
        InstantiateHiddenEnemy();
        InstantiateProp();
    }

    private void InstantiateProp()
    {
        instantiatedProp = Instantiate(props[(int)Random.Range(0, props.Length)], this.gameObject.transform);
        instantiatedProp.gameObject.tag = "GlitchedProp";
    }

    public void InstantiateHiddenEnemy()
    {
        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        GameObject enemy = Instantiate(enemies[(int)Random.Range(0, enemies.Length)].gameObject, spawnPoint.position, Quaternion.identity);
        enemy.transform.parent = this.transform;
        collider = enemy.GetComponent<Enemy>().enemyCollider;
        collider.SetActive(false);
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = enemyRotation;
        spawnedEnemy = enemy;
    }

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        HiddenObjects hiddenScript = spawnedEnemy.GetComponentInChildren<HiddenObjects>();
        //collider.SetActive(true);
        hiddenScript.ShowHiddenObject();
        spawnedEnemy.GetComponent<StateController>().currentState.isDone = true;
        hiddenScript.enabled = false;
    }

    public void DestroySpawner()
    {
        Instantiate(destroyParticles, this.gameObject.transform.position, Quaternion.identity);
        //spawnManager.spawners.Remove(this);
        //Destroy(this.transform.parent.gameObject);
        Debug.Log("hola");
    }

    public void RemoveSpawner()
    {
#if UNITY_EDITOR
        Undo.RegisterCompleteObjectUndo(spawnManager, "RemoveSpawner");
#endif
        spawnManager.spawners.Remove(this);
    }

    public void SetSpawnerManager(EnemySpawnManager enemySpawnManager)
    {
#if UNITY_EDITOR
        Undo.RegisterCompleteObjectUndo(enemySpawnManager, "SetSpawnerManager");
#endif
        spawnManager = enemySpawnManager;
    }
}
