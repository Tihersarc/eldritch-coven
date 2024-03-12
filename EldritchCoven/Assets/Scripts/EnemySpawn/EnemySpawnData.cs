using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnData : MonoBehaviour
{
    [SerializeField] Mesh[] propsMeshes;
    [SerializeField] Enemy[] enemies;

    public void Spawn()
    {
        this.GetComponent<MeshFilter>().mesh = propsMeshes[(int) Random.Range(0, propsMeshes.Length)];

        Quaternion enemyRotation = Quaternion.LookRotation(GameLogic.instance.playerController.transform.position - this.transform.position);
        Instantiate(enemies[(int)Random.Range(0, propsMeshes.Length)].gameObject, this.transform.position, enemyRotation);
    }
}
