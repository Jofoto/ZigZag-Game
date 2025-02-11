using UnityEngine;

public class Diamond : MonoBehaviour
{
   public float rotateSpeed;
   
      private void FixedUpdate(){
        transform.Rotate(0, rotateSpeed, 0);
    }
}
