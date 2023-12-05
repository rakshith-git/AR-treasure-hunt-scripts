using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform target;  // Reference to the target plane or object to follow.
    public Vector3 offset;   // Offset from the target position.

    void Update()
    {
        if (target != null)
        {
            // Calculate the desired camera position.
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position.
            transform.LookAt( Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime));
        }
    }
}

