using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class InputRemapping_RebindInputButton : MonoBehaviour
{
    public string actionToRemap;
    private void Awake()
    {
        UnityEngine.UI.Button button = GetComponentInParent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => GetComponentInParent<InputRemapping_DynamicInputRemapping>().ListenToActionRemap(actionToRemap, button));
    }

    private void OnEnable()
    {
        ResetName();
    }

    public void ResetName()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GetKeyNameFromBinding(GetBindingForInputAction(GetActionNamed(actionToRemap))); ;
    }

    public InputAction GetActionNamed(string a)
    {
        InputRemapping_DynamicInputRemapping dir = GetComponentInParent<InputRemapping_DynamicInputRemapping>();
        return dir.inputActionAsset.FindAction(actionToRemap);
    }

    public InputBinding GetBindingForInputAction(InputAction a)
    {
        InputBinding activeBinding = GetActiveBinding(a);
        return activeBinding;
    }
    private InputBinding GetActiveBinding(InputAction action)
    {
        foreach (var binding in action.bindings)
        {
            if (binding.isPartOfComposite)
            {
                // Skip bindings that are part of a composite
                continue;
            }

            // Check if the binding is currently active
            return binding;

        }
        InputBinding nullBinding = new InputBinding();
        return nullBinding;
    }


    private string GetKeyNameFromBinding(InputBinding binding)
    {
        return binding.ToDisplayString();
    }

}