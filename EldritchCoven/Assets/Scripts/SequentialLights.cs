using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialLights : MonoBehaviour
{
    [SerializeField] GameObject[] chandeliers;
    [SerializeField] float delay;
    int index = 0;

    public void StartLights()
    {
        InvokeRepeating("ActivateChandelier", delay, delay);
        
    }

    void ActivateChandelier()
    {
        if (index < chandeliers.Length)
        {
            chandeliers[index].SetActive(true);
            index++;
        }
        else
        {
            CancelInvoke();
        }
    }


}
