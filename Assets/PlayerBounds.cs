using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public GameObject planeObject; // Assign your plane GameObject here

    private Vector3 minBounds;
    private Vector3 maxBounds;

    void Start()
    {
        // Assuming the plane has a BoxCollider to define its bounds
        BoxCollider collider = planeObject.GetComponent<BoxCollider>();
        if (collider != null)
        {
            // Calculate the min and max bounds of the plane
            minBounds = collider.bounds.min;
            maxBounds = collider.bounds.max;
        }
    }

    void Update()
    {
        // Restrict the player's position within the bounds of the plane
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            transform.position.y, // Assuming you want to restrict only on X and Z axes
            Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z)
        );
    }
}