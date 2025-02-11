using UnityEngine;
// spawn new platforms in x, z positions
public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;
    public bool gameOver;
    
    void Start()
    {
        lastPos = platform.transform.position; //pos where previous platform was 
        size = platform.transform.localScale.x;

        for(int i =0; i < 20; i++) //generate 20 platforms at Start
        {
            SpawnPlatforms();
        }

       
    }

    public void StartSpawiningPlatforms()
    {
         InvokeRepeating("SpawnPlatforms", 0.5f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6); //generate up to 5 platforms

        if(rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos; //update last pos to new pos

        Instantiate(platform, pos, Quaternion.identity);

        //generate rand num between 0, 4
        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1.2f, pos.z), Quaternion.identity); //if num is 0, instantiate diamond. if it's 1,2 or 3 then no diamonds
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos; //update last pos to new pos

        Instantiate(platform, pos, Quaternion.identity);

         int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1.2f, pos.z), Quaternion.identity);
        }
    }
}
