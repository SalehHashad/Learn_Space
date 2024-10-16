using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to change the cube's movement speed.

    void Update()
    {
        // Read the user's input from the arrow keys (left, right, up, down).
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector based on the arrow key input and speed.
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Translate the cube's position based on the calculated movement.
        transform.Translate(movement);
    }
}
