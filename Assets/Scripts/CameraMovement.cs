using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5f; // Adjust this value as needed

    void Update()
    {
        // Move the camera to the right
        transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
    }
}
