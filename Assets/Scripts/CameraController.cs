using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Player character to follow
    public float distance = 5.0f; // Distance from the player
    public float height = 2.0f; // Height above the player
    public float rotationSpeed = 2.0f; // Speed of camera rotation
    public float minVerticalAngle = -20.0f; // Minimum vertical angle
    public float maxVerticalAngle = 80.0f; // Maximum vertical angle

    private float currentRotationX = 0.0f;
    private float currentRotationY = 0.0f;

    void LateUpdate()
    {
        if (!target)
            return;

        // Rotate the camera based on mouse input
        currentRotationX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotationY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentRotationY = Mathf.Clamp(currentRotationY, minVerticalAngle, maxVerticalAngle);

        // Calculate the desired rotation angle around the player
        Quaternion rotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);

        // Adjust the camera's position based on the desired angle and distance
        Vector3 targetPosition = target.position - (rotation * Vector3.forward * distance) + (Vector3.up * height);

        // Smoothly interpolate the camera's position and rotation
        transform.position = targetPosition;
        transform.rotation = rotation;
    }
}