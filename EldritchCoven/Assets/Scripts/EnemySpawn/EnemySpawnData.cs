using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class EnemySpawnData : MonoBehaviour
{
    [SerializeField] Mesh[] propsMeshes;
    [SerializeField] Enemy[] enemies;
    private void Start()
    {
        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        GameObject enemy = Instantiate(enemies[(int)Random.Range(0, propsMeshes.Length)].gameObject, this.gameObject.transform);
        enemy.transform.position = this.transform.position;
        enemy.transform.rotation = enemyRotation;
    }

    public void Spawn()
    {
        this.GetComponent<MeshFilter>().mesh = propsMeshes[(int) Random.Range(0, propsMeshes.Length)];

        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        GameObject enemy = Instantiate(enemies[(int)Random.Range(0, propsMeshes.Length)].gameObject, this.gameObject.transform);
        enemy.transform.rotation = enemyRotation;
    }

    private void OnEnable()
    {
        EnemySpawnManager.instance.spawners.Add(this);
    }
}
