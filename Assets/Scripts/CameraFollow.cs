using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    public float lerpRate;
    public bool gameOver;

    void Start()
    {
        offset = ball.transform.position - transform.position; //subtract position of camera from position of ball to get the distance to always be the same
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);

        transform.position = pos;
    }
}
