using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCameraController : MonoBehaviour
{
    public Transform target; // The target GameObject that the camera will follow (e.g., the player).
    public Vector3 offset = new Vector3(0f, 2f, -5f); // The camera's position offset from the target.

    void LateUpdate()
    {
        // Calculate the new camera position based on the target's position and the offset.
        Vector3 newPosition = target.position + offset;

        // Set the camera's position to the new calculated position.
        transform.position = newPosition;

        // Make the camera look at the target.
        transform.LookAt(target);
    }
}