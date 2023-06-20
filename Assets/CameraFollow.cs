using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the player's transform

    public Vector3 offset = new Vector3(0f, 5f, -10f);  // Offset the camera's position

    void LateUpdate()
    {
        // Update the camera's position to match the player's position with the offset
        transform.position = target.position + offset;
    }
}
