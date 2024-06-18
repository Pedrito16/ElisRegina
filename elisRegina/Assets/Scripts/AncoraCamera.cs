using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncoraCamera : MonoBehaviour
{
    private Vector3 cameraTransform;
    public Transform cam;
    private void Update()
    {
        cameraTransform = cam.position - transform.position;
        cam.position = transform.position + cameraTransform;
    }
}
