using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBehaviuor : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = .3f;
    [SerializeField] float stepSmooth = 2f;
    [SerializeField] float stepRange;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        //stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    private void FixedUpdate()
    {
        //if (rigidBody.velocity != Vector3.zero)
        //    StepClimb();
    }

    public void StepClimb()
    {
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.forward, out hitLower, stepRange))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.forward, out hitUpper, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLower45;
        if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, -45, 0) * transform.forward, out hitLower45, stepRange))
        {

            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, -45, 0) * transform.forward, out hitUpper45, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, 45, 0) * transform.forward, out hitLowerMinus45, stepRange))
        {

            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, 45, 0) * transform.forward, out hitUpperMinus45, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLower90;
        if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, 90, 0) * transform.forward, out hitLower90, stepRange))
        {

            RaycastHit hitUpper90;
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, 90, 0) * transform.forward, out hitUpper90, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLowerMinus90;
        if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, -90, 0) * transform.forward, out hitLowerMinus90, stepRange))
        {

            RaycastHit hitUpperMinus90;
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, -90, 0) * transform.forward, out hitUpperMinus90, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLower135;
        if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, 135, 0) * transform.forward, out hitLower135, stepRange))
        {

            RaycastHit hitUpper135;
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, 135, 0) * transform.forward, out hitUpper135, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLowerMinus135;
        if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, -135, 0) * transform.forward, out hitLowerMinus135, stepRange))
        {

            RaycastHit hitUpperMinus135;
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, -135, 0) * transform.forward, out hitUpperMinus135, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }
}