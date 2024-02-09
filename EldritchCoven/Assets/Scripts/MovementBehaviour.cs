using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float speed;

    [SerializeField] private Transform stairHighRay;
    [SerializeField] private Transform stairLowRay;
    [SerializeField] StudioEventEmitter stepsEmitter;
    [SerializeField] float stepsEmissionRatio;
    float timeMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (timeMoving >= stepsEmissionRatio)
        {
            timeMoving = 0;
            stepsEmitter.Play();
        }
    }

    public void MoveRB(Vector3 direction)
    {
        Vector3 playerVelocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);

        rb.velocity = transform.TransformDirection(playerVelocity);
        timeMoving += Time.deltaTime;
    }

    public void StopRB()
    {
        timeMoving = 0;
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
    }
}
