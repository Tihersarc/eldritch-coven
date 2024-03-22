using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float totalTime = 300f;
    float timeRemaining;

    [SerializeField] GameObject monster;

    [SerializeField] Transform mirrorCamera;
    [SerializeField] Transform cameraEndPoint;
    Vector3 initialCameraPosition;
    [SerializeField] Transform[] spawnPoints;
    bool onEnd = false;

    public UnityEvent onTimeOut;

    private void Start()
    {
        timeRemaining = totalTime;
        initialCameraPosition = mirrorCamera.position;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            float fractionElapsed = 1 - (timeRemaining / totalTime);
            mirrorCamera.position = Vector3.Lerp(initialCameraPosition, cameraEndPoint.position, fractionElapsed);
        }
        else
        {
            if (!onEnd)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
                Instantiate(monster, spawnPoint.position, spawnPoint.rotation);
                onEnd = true;
            }
                

            onTimeOut.Invoke();
        }
    }
}
