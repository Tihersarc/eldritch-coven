using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float totalTime = 300f;
    float timeRemaining;

    private void Start()
    {
        timeRemaining = totalTime;
    }
}
