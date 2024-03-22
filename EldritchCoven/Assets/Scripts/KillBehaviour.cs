using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillBehaviour : MonoBehaviour
{
    public static Action onKill;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PauseBehaviour.Instance.IsPaused = true;
            Time.timeScale = 0f;
            Debug.Log("UwU");
            onKill.Invoke();
        }
    }
}
