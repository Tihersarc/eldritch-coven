using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectInHand : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    public void ChangeObject()
    {
        inventory.NextItem();
    }
}
