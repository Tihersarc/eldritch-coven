using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] portals;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var p in portals)
        {
            p.gameObject.SetActive(false);
        }

        this.gameObject.SetActive(false);
    }
}
