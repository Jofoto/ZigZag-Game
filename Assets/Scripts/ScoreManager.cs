using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;
    public int highScore;
    public int Dscore;
    public int DHscore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;    
        }
    }
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore()
    {
        score += 1;
    }

    public void incrementDScore()
    {
        Dscore += 1;
        PlayerPrefs.SetInt("Dscore", Dscore);

         // Update the UI to show the new diamond score
        UIManager.instance.UpdateDiamondScore(Dscore);

        // Save new Diamond High Score if needed
        if (Dscore > DHscore)
        {
            DHscore = Dscore;
            PlayerPrefs.SetInt("DHscore", DHscore);
        }
    }

    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    public void stopScore()
    {
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
