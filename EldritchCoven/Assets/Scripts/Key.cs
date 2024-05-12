using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject keyPrefab;
    public void Interact()
    {
        GameLogic.instance.playerController.GetComponent<Inventory>().AddItemToInventory(keyPrefab);
        this.gameObject.SetActive(false);
    }
}
