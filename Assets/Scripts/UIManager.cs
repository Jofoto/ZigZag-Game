using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public TMP_Text score;
    public TMP_Text highScore1;
    public TMP_Text highScore2;
    public TMP_Text Dscore; //diamond score
    public TMP_Text DHscore; //diamond high score

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        DHscore.text = PlayerPrefs.GetInt("DHscore").ToString();
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        //zigzagPanel.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelUp");
        zigzagPanel.SetActive(false);
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    
    public void UpdateDiamondScore(int newDScore)
    {
        Dscore.text = newDScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

   public void Exit(){
        Application.Quit();
    }


}
