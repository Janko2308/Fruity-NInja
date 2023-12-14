using UnityEngine;

public class MockVRControllerInput : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float turnSpeed = 45.0f;

    // Update is called once per frame
    void Update()
    {
        // Simulate controller position movement with arrow keys
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Simulate controller rotation with Q and E for left and right rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Simulate button presses
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Simulated Button Pressed: Space");
            // Add logic for what happens when the VR controller button is pressed
        }

        // Simulate trigger press
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Debug.Log("Simulated Trigger Pressed");
            // Add logic for what happens when the VR controller trigger is pressed
        }
    }
}