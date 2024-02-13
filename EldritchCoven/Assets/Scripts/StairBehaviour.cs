using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBehaviuor : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepSmooth = 2f;
    [SerializeField] float stepRange;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Check all the directions in steps of 45 degrees using raycasts to check if the player needs to go up stairs
    public void StepClimb()
    {
        if (Physics.Raycast(stepRayLower.transform.position, transform.forward, out RaycastHit hitLower, stepRange))
        {
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.forward, out RaycastHit hitUpper, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
        else if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, -45, 0) * transform.forward, out RaycastHit hitLower45, stepRange))
        {
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, -45, 0) * transform.forward, out RaycastHit hitUpper45, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
        else if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, 45, 0) * transform.forward, out RaycastHit hitLowerMinus45, stepRange))
        {
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, 45, 0) * transform.forward, out RaycastHit hitUpperMinus45, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
        else if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, 90, 0) * transform.forward, out RaycastHit hitLower90, stepRange))
        {
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, 90, 0) * transform.forward, out RaycastHit hitUpper90, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
        else if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, -90, 0) * transform.forward, out RaycastHit hitLowerMinus90, stepRange))
        {
            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, -90, 0) * transform.forward, out RaycastHit hitUpperMinus90, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
        else if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, 135, 0) * transform.forward, out RaycastHit hitLower135, stepRange))
        {

            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, 135, 0) * transform.forward, out RaycastHit hitUpper135, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
        else if (Physics.Raycast(stepRayLower.transform.position, Quaternion.Euler(0, -135, 0) * transform.forward, out RaycastHit hitLowerMinus135, stepRange))
        {

            if (!Physics.Raycast(stepRayUpper.transform.position, Quaternion.Euler(0, -135, 0) * transform.forward, out RaycastHit hitUpperMinus135, stepRange + 0.1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }
}