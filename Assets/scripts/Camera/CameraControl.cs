using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform lookAt;

    
    void Update()
    {
        CameraFollow(lookAt);
    }

    void CameraFollow(Transform target)
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
