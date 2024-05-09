using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class InputRemapping_DynamicInputRemapping : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    [HideInInspector] public bool listeningToRebind = false;
    [HideInInspector] public string actionToRemap;
    [HideInInspector] public UnityEngine.UI.Image actionToRemapButtonImage;
    Material originalMaterial;
    [SerializeField] Color rebindingColor = new Color(255, 0, 0);
    private void Awake()
    {
        LoadCustomKeybindings();
    }
    private void Update()
    {
        if (listeningToRebind)
        {
            RemapAction(actionToRemap);
        }
    }

    public void ListenToActionRemap(string actionToRemap, UnityEngine.UI.Button button)
    {
        listeningToRebind = true;
        this.actionToRemap = actionToRemap;
        Image image = button.GetComponent<Image>();
        actionToRemapButtonImage = image;
        originalMaterial = image.material;
        Material newMaterial = new Material(image.material);
        image.material = newMaterial;

        // Change the color of the new material instance
        newMaterial.color = rebindingColor;

    }

    public void StopListeningToActionRemap()
    {
        if (listeningToRebind)
        {
            listeningToRebind = false;
            actionToRemapButtonImage.material = originalMaterial;
            actionToRemap = "";
            actionToRemapButtonImage = null;
        }
    }


    private void RemapAction(string actionName)
    {
        InputAction actionToRemap = inputActionAsset.FindAction(actionName);
        actionToRemap.Disable();
        if (actionToRemap != null)
        {
            //Debug.Log($"Press a key or button to remap {actionName}...");

            // Start the rebinding process
            actionToRemap
                .PerformInteractiveRebinding()
                .OnMatchWaitForAnother(0.0f) // Wait for a short time after a key press
                .OnComplete(operation => {
                    //Debug.Log($"Remapped {actionName} to: {operation.selectedControl}");
                    SaveCustomKeybinding(actionName, operation.selectedControl);
                    ResetAllRebindInputButtonNames();
                    StopListeningToActionRemap();
                })
                .OnCancel(operation => {
                    //Debug.Log($"Remapping {actionName} canceled.");
                })
                .Start();
        }
        else
        {
            Debug.LogError($"Action {actionName} not found in the InputActionAsset.");
        }
        actionToRemap.Enable();
    }

    private void ResetAllRebindInputButtonNames()
    {
        if (listeningToRebind)
        {
            foreach (InputRemapping_RebindInputButton r in GetComponentsInChildren<InputRemapping_RebindInputButton>())
            {
                r.ResetName();
            }
        }
    }

    private void SaveCustomKeybinding(string actionName, InputControl control)
    {
        if (listeningToRebind)
        {
            // Save custom keybinding to storage
            // Example:
            PlayerPrefs.SetString(actionName, control.path);
            Debug.Log($"Saved keybinding for {actionName}: {control.path}");
        }
    }

    private void LoadCustomKeybindings()
    {
        // Load custom keybindings from storage for each action in the InputActionAsset
        foreach (var action in inputActionAsset)
        {
            string actionName = action.name;
            string savedKeybinding = PlayerPrefs.GetString(actionName);

            if (!string.IsNullOrEmpty(savedKeybinding))
            {
                ApplyKeybinding(action, savedKeybinding);
            }
        }
    }

    private void ApplyKeybinding(InputAction action, string keybinding)
    {
        // Create a new array with the modified binding
        //InputBinding[] newBindings = { new InputBinding { path = keybinding } };

        // Set the new bindings for the action
        action.ApplyBindingOverride(keybinding);
        //Debug.Log($"Loaded keybinding for {action.name}: {keybinding}");
    }

}
