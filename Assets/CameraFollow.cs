using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;        // The object for the camera to follow

    [Header("Position Settings")]
    public Vector3 offset = new Vector3(0, 5, -10);  // Offset from the target
    public float smoothSpeed = 0.125f;               // Smoothness factor (lower = smoother/slower)

    [Header("Rotation Settings")]
    public bool followRotation = false;              // Optionally follow target rotation
    public float rotationSmoothSpeed = 5f;           // Rotation smooth speed

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position based on target + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Optionally look at target
        transform.LookAt(target);

        // Optionally smooth rotation
        if (followRotation)
        {
            Quaternion desiredRotation = target.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed * Time.deltaTime);
        }
    }
}
