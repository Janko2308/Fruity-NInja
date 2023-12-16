using UnityEngine;

public class PlayerMovementLimiter : MonoBehaviour
{
    private CharacterController characterController;

    // Define the movement boundaries
    private float minX = -0.06f;
    private float maxX = 3.5f;
    private float minZ = -0.03f;
    private float maxZ = 2.0f;

    void Start()
    {
        // Get the CharacterController component from the player GameObject
        characterController = GetComponent<CharacterController>();
        
        if (!characterController)
        {
            Debug.LogError("CharacterController component not found on the player GameObject.");
        }
    }

    void Update()
    {
        // Get the current position
        Vector3 position = transform.position;

        // Clamp the position within the specified ranges
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);
        Debug.Log("Position: " + position);

        // Apply the clamped position
        transform.position = position;

        // If using the CharacterController to move the player, add the movement code here
        // and make sure to apply the clamped position after the movement calculations
    }
}