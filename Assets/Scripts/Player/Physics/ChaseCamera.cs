using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    [SerializeField]
    private float smoothSpeed = 0.125f;

    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 20, -20);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
