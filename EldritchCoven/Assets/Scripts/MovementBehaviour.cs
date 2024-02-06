using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float speed;

    [SerializeField] private Transform stairHighRay;
    [SerializeField] private Transform stairLowRay;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //StairClimb();
    }

    public void MoveRB(Vector3 direction)
    {
        Vector3 playerVelocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);

        //rb.velocity = playerVelocity;

        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    public void StopRB()
    {
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f); 
    }
}
