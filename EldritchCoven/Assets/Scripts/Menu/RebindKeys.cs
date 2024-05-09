using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindKeys : MonoBehaviour
{
    [SerializeField] PlayerInput[] playerInputs;
    [SerializeField] InputActionAsset inputActionAsset;

    private void Start()
    {
        PauseBehaviour.onKeysChanged += CopyOverridenBindings;
    }

    private void CopyOverridenBindings()
    {
        for (int k = 0; k < playerInputs.Length; k++)
        {
            InputActionMap copyActionMap = playerInputs[k].actions.FindActionMap("Player");

            InputActionMap originalActionMap = inputActionAsset.FindActionMap("Player");

            for (int i = 0; i < copyActionMap.actions.Count; i++)
            {
                var copyAction = copyActionMap.actions[i];
                var originalAction = originalActionMap.actions[i];
                for (int j = 0; j < copyAction.bindings.Count; j++)
                {
                    var originalBinding = originalAction.bindings[j];
                    if (originalBinding.overridePath != null
                        && originalBinding.overridePath != string.Empty)
                    {
                        copyAction.ChangeBinding(j).WithPath(originalBinding.overridePath);
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        PauseBehaviour.onKeysChanged -= CopyOverridenBindings;
    }
}
