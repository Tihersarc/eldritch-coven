using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public List<GameObject> objetctsInInventory;
    [SerializeField]
    private Animator objectInHandAnim;

    public void AddItemToInventory(GameObject newObject)
    {
        objetctsInInventory.Add(newObject);
    }

    public void RemoveItemFromInventory(GameObject objectToRemove)
    {

    }

    public void OnChangeItem(InputValue input)
    {
        if (!PauseBehaviour.Instance.IsPaused)
        {
            if (input.Get<Vector2>().y < 0)
            {
                objectInHandAnim.SetTrigger("TriggerObject");
            }
        }
    }
}
