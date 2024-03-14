using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class EnemySpawnData : MonoBehaviour
{
    [SerializeField] Mesh[] propsMeshes;
    [SerializeField] Enemy[] enemies;
    [SerializeField] Transform spawnPoint;
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        this.GetComponent<MeshFilter>().mesh = propsMeshes[(int) Random.Range(0, propsMeshes.Length)];

        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        GameObject enemy = Instantiate(enemies[(int)Random.Range(0, enemies.Length)].gameObject, this.gameObject.transform);
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = enemyRotation;
    }

    private void OnEnable()
    {
        EnemySpawnManager.instance.spawners.Add(this);
    }
}
