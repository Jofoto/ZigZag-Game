using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;
    [SerializeField] private float speed;
    bool started;
    bool gameOver;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.linearVelocity = new Vector3(speed,0,0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

    
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.linearVelocity = new Vector3(0, -25f ,0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.linearVelocity.z > 0)
        {
            rb.linearVelocity = new Vector3(speed,0,0);
        }
        else if(rb.linearVelocity.x > 0)
        {
            rb.linearVelocity = new Vector3(0,0,speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);

            // Increase the diamond score
            ScoreManager.instance.incrementDScore();
        }
    }
}
