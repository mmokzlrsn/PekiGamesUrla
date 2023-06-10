using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target; // Reference to the target object
    public Vector3 offset; // Offset between the camera and the target

    public float moveSpeed = 5f; // Speed at which the camera follows the target

    private void Start()
    {
        FocusOnTarget();
    }

    void Update()
    {
        if (target != null)
        {
            LerpToTarget();
        }
    }

    public void FocusOnTarget()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;

        // Move the camera towards the target position
        transform.position = targetPosition;
    }

    public void LerpToTarget()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;

        // Move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
        