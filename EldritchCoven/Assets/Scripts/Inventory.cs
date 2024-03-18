using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objetcsInInventory;
    private int currentItem;
    private Animator objectInHandAnim;
    [SerializeField]
    private GameObject hand;

    private void Start()
    {
        objectInHandAnim = hand.GetComponent<Animator>();
        currentItem = 0;
    }

    public void AddItemToInventory(GameObject newObject)
    {
        objetcsInInventory.Add(newObject);
    }

    public void RemoveItemFromInventory(GameObject objectToRemove)
    {
        objetcsInInventory.Remove(objectToRemove);
    }

    public void NextItem()
    {
        Destroy(hand.transform.GetChild(0).gameObject);
        Instantiate(objetcsInInventory[currentItem], hand.transform);
    }

    public void OnChangeItem(InputValue input)
    {
        if (input.Get<Vector2>().y < 0)
        {
            if (--currentItem < 0)
            {
                currentItem = objetcsInInventory.Count - 1;
            }
            objectInHandAnim.SetTrigger("TriggerObject");
        }

        if (input.Get<Vector2>().y > 0)
        {
            if (++currentItem >= objetcsInInventory.Count)
            {
                currentItem = 0;
            }
            objectInHandAnim.SetTrigger("TriggerObject");
        }

    }
}
