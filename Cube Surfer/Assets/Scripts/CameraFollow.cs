using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 smoothSpeed=Vector3.zero;
    public Vector3 offset;
    
    void Update()
    {
        Vector3 desiredPosition = new Vector3(target.position.x,target.position.y,target.position.z/4f) + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref smoothSpeed, smoothTime);
        transform.position = smoothedPosition;
        //transform.LookAt(target);
    }
}
