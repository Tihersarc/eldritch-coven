using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PortalGenerationTool))]
public class PortalGenerationToolEditor : Editor
{

    Portal portal1;

    private void OnSceneGUI()
    {
        PortalGenerationTool tool = (PortalGenerationTool)target;
        Selection.activeGameObject = ((PortalGenerationTool)target).gameObject;

        if (Event.current.type == EventType.MouseDown)
        {
            if (Event.current.button == 0)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitDebug, float.MaxValue, -1, QueryTriggerInteraction.Ignore))
                {
                    if (hitDebug.collider.name == "PortalPlane")
                    {
                        Transform planeTransform = hitDebug.collider.transform;
                        GameObject portal = Instantiate(tool.portalPrefab, planeTransform.position, planeTransform.rotation, planeTransform.parent);
                        portal.transform.SetParent(planeTransform.parent);
                        Undo.RegisterCreatedObjectUndo(portal, "InstanciaPortal");
                        Undo.DestroyObjectImmediate(planeTransform.gameObject);

                        HandlePortal(portal);

                    }
                }
            }

        }
    }

    private void HandlePortal(GameObject newInstantiatedPortalObject)
    {
        if (portal1 == null)
        {
            portal1 = newInstantiatedPortalObject.GetComponentInChildren<Portal>();
        }
        else
        {
            //Referenciar portales entre ellos y borrar referencias

            Portal portal2 = newInstantiatedPortalObject.GetComponentInChildren<Portal>();

            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController)
            {
                portal1.SetPlayerController(playerController);
                portal2.SetPlayerController(playerController);
            }


            Undo.RegisterCompleteObjectUndo(portal1, "AssignOtherPortal");
            Undo.RegisterCompleteObjectUndo(portal2, "AssignOtherPortal");

            portal1.exit = portal2;
            portal2.exit = portal1;

            PortalTextureSetup portalTextureSetup = FindObjectOfType<PortalTextureSetup>();
            if (portalTextureSetup)
            {
                Undo.RegisterCompleteObjectUndo(portalTextureSetup, "AssignOtherPortal");
                portalTextureSetup.AddPortal(portal1.gameObject);
                portalTextureSetup.AddPortal(portal2.gameObject);
            }

            portal1 = null;

        }
    }
}
