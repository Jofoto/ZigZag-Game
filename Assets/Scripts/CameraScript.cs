using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; //so that camera always looks at target
 
    void FixedUpdate(){
        transform.LookAt(target);
    }
}
