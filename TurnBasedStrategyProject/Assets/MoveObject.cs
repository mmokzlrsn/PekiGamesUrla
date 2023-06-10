using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f; // Desired speed of the object
    public float directionChangeInterval = 1f; // Time interval between direction changes

    private Vector3 currentDirection = Vector3.right; // Current movement direction
    private Vector3 desiredDirection = Vector3.right; // Desired movement direction
    private float timeSinceLastDirectionChange = 0f; // Time elapsed since the last direction change

    private void Update()
    {
        // Calculate the translation distance for this frame
        float translation = speed * Time.deltaTime;

        // Update the time elapsed since the last direction change
        timeSinceLastDirectionChange += Time.deltaTime;

        // Check if it's time to change the direction
        if (timeSinceLastDirectionChange >= directionChangeInterval)
        {
            // Generate a random direction on the XZ plane
            desiredDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            // Reset the time since the last direction change
            timeSinceLastDirectionChange = 0f;
        }

        // Lerp the current direction towards the desired direction
        currentDirection = Vector3.Lerp(currentDirection, desiredDirection, Time.deltaTime * speed);

        // Move the object along the current direction on the XZ plane
        transform.Translate(new Vector3(currentDirection.x, 0f, currentDirection.z) * translation);
    }
}
