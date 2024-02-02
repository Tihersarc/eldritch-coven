using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float speed;

    [SerializeField] private Transform stairHighRay;
    [SerializeField] private Transform stairLowRay;
    [SerializeField] private float stairRange = .5f;
    [SerializeField] private float stairSmooth = .01f;

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
        Vector3 playerVelocity = new Vector3(direction.x, 0, direction.y
            ) * speed;
        rb.velocity = transform.TransformDirection(playerVelocity);
        //GetComponent<CharacterController>().SimpleMove(playerVelocity);
    }

    private void StairClimb()
    {
        RaycastHit hitLow;
        Debug.DrawLine(stairLowRay.transform.position, stairLowRay.transform.position + transform.forward * stairRange);
        //Debug.DrawRay(stairHighRay.transform.position, transform.forward);

        if (Physics.Raycast(stairLowRay.transform.position, transform.forward, out hitLow, stairRange))
        {
            RaycastHit hitHigh;
            
            if (!Physics.Raycast(stairHighRay.transform.position, transform.forward, out hitHigh, .2f))
            {
                rb.position -= new Vector3(0f, -stairSmooth, 0f);
            }
        }
    }
}
