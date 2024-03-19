using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class EnemySpawner
    : MonoBehaviour
{
    [SerializeField] Mesh[] propsMeshes;
    [SerializeField] Enemy[] enemies;
    [SerializeField] Transform spawnPoint;
    HiddenObjects hiddenScript;
    StateController stateController;

    private void Start()
    {
        InstantiateEnemy();
        hiddenScript = GetComponent<HiddenObjects>();
        stateController = GetComponent<StateController>();
    }

    public void InstantiateEnemy()
    {
        this.GetComponent<MeshFilter>().mesh = propsMeshes[(int) Random.Range(0, propsMeshes.Length)];

        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        GameObject enemy = Instantiate(enemies[(int)Random.Range(0, enemies.Length)].gameObject, this.gameObject.transform);
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = enemyRotation;
    }

    public void Spawn()
    {
        hiddenScript.enabled = false;
        gameObject.layer = 0;
        stateController.enabled = true;
    }

    private void OnEnable()
    {
        EnemySpawnManager.instance.spawners.Add(this);
    }
}
