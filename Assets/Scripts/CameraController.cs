using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float min = -45;
    public float max = 45;
    public float cameraSmoothingFactor = 5;

    private Quaternion camRotation;
    void Start()
    {
        camRotation = transform.localRotation;
    }

    void Update()
    {
        // Debug.Log(Input.GetAxis("Mouse X") + "  :  " + Input.GetAxis("Mouse Y"));
        camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor * (-1);
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor;

        camRotation.x = Mathf.Clamp(camRotation.x, min, max);
        camRotation.y = Mathf.Clamp(camRotation.y, min, max);
        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
