using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ╫л╠шео
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject reTryBtn;

    public int score = 0;
    public bool isGameOver = false;
    public int bestScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            bestScore = PlayerPrefs.GetInt("BestScore");
            bestScoreText.text = "Best Score : " + bestScore;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameStart()
    {
        //titleText.SetActive(false);
        //isStart = true;
        SceneManager.LoadScene(1);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        //scoreText.text = score.ToString();
        //scoreText.text = $"Score : {score.ToString()}";
        scoreText.text = "Score : " + score;
    }

    public void OnPlayerDead()
    {
        isGameOver = true;

        gameOverText.SetActive(true);
        reTryBtn.SetActive(true);
        bestScoreText.gameObject.SetActive(true);

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);

            bestScore = PlayerPrefs.GetInt("BestScore");
            bestScoreText.text = "Best Score : " + bestScore;
            
            bestScoreText.gameObject.SetActive(true);
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(1);
    }
}
