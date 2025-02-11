using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log("Ball exited trigger, making platform fall...");

        if(col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);
            
        }
    }

    void FallDown()
    {
        Rigidbody rb = GetComponentInParent<Rigidbody>();
        //GetComponentInParent<Rigidbody>().isKinematic = false;
        if (rb != null)
    {
        rb.isKinematic = false;  // Allow physics interaction
        rb.useGravity = true;    // Enable gravity
        rb.AddForce(Vector3.down * 10, ForceMode.Impulse);  // Apply downward force

        Debug.Log("Platform is falling");
    }

        Destroy(transform.parent.gameObject, 2f);
    }
}
