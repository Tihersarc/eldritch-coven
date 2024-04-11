using System.Diagnostics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    private void OnDestroy()
    {
        EnemySpawner enemy = ((EnemySpawner)target);

        if (Application.isEditor)
        {
            if (enemy == null)
            {
                enemy.RemoveSpawner();
            }
                UnityEngine.Debug.Log("hola");
        }
    }
}
