using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5f; // Adjust this value as needed


    private void Start()
    {
        MovingBackground movingBackground = GetComponentInChildren<MovingBackground>();
        if (movingBackground != null)
        {
            movingBackground.BackgroundSpeed = cameraSpeed;
        }
        else
        {
            Debug.LogWarning("MovingBackground component not found in any child objects.");
        }
    }
    void FixedUpdate()
    {
        // Move the camera to the right
        transform.Translate(cameraSpeed * Time.deltaTime * Vector3.right);
    }
}
