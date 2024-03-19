using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    Camera referenceCam;

    void Start()
    {
        referenceCam = Camera.main;
    }

    void Update()
    {
        Vector3 reflectedVector = Vector3.Reflect(referenceCam.transform.forward, this.transform.parent.forward);
        
    }
}
