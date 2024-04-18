using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawnManager))]
public class EnemySpawnMangerEditor : Editor
{
    const float rayDistance = 1000.0f;
    bool instancing = false;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EnemySpawnManager enemySpawnManager = (EnemySpawnManager)target;
        if (GUILayout.Button(instancing ? "Stop instancing" : "Start instancing"))
        {
            instancing = !instancing;
        }
        if (GUILayout.Button("Clear null refs"))
        {
            Undo.RegisterCompleteObjectUndo(enemySpawnManager, "RemoveAllNulls");
            enemySpawnManager.spawners.RemoveAll(IsNull);

        }

    }

    private void OnSceneGUI()
    {
        EnemySpawnManager enemySpawnManager = (EnemySpawnManager)target;
        if (instancing)
        {
            Selection.activeGameObject = enemySpawnManager.gameObject;

            if (Event.current.button == 0)
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    if (enemySpawnManager.GetSpawnerPrefab() != null)
                    {

                        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit, rayDistance))
                        {
                            Undo.RegisterCompleteObjectUndo(enemySpawnManager, "InstantiateSpawner");
                            GameObject instantiatedSpawner = Instantiate(enemySpawnManager.GetSpawnerPrefab(), hit.point, Quaternion.identity);
                            EnemySpawner instancedSpawner = instantiatedSpawner.GetComponent<EnemySpawner>();
                            enemySpawnManager.spawners.Add(instancedSpawner);
                            instancedSpawner.SetSpawnerManager(enemySpawnManager);
                            Undo.RegisterCreatedObjectUndo(instancedSpawner, "InstantiateSpawner");
                        }
                    }

                }
            }
        }


    }

    bool IsNull<T>(T anInstance) where T : MonoBehaviour
    {
        return anInstance == null;
    }

}
