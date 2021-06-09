using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject ingameHS;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject backgroundMusic;


    [SerializeField] int gameLevelNumber;

    [SerializeField] Text scoreDisplay1;
    [SerializeField] Text scoreDisplay2;
    [SerializeField] Text highScore;
    [SerializeField] Text endgameHS;
    public AudioClip soundBall;

    [SerializeField] float speedScore;
    int myScore = -1;

    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void GameOver()
    {
        if (myScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", myScore);
            highScore.text = myScore.ToString();
        }
        endgameHS.text = highScore.text;
        ingameHS.SetActive(false);
        gameOverPanel.SetActive(true);
        mainPanel.SetActive(false);
        backgroundMusic.SetActive(false);


    }

    public void Restart()
    {
        SceneManager.LoadScene(gameLevelNumber);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        backgroundMusic.SetActive(true);

    }
    public void Pause()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        backgroundMusic.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void TurnButton()
    {
        if (!BallMovement.instance.isStarted)
        {
            BallMovement.instance.isStarted = true;
            startPanel.SetActive(false);
            backgroundMusic.SetActive(true);
        }
        BallMovement.instance.isGoingRight = !BallMovement.instance.isGoingRight;
        SoundManager.PlaySound();
        AddScore();
    }
    void AddScore()
    {
        myScore++;
        scoreDisplay1.text = myScore.ToString();
        scoreDisplay2.text = myScore.ToString();
        SpeedUp();
    }

    void SpeedUp()
    {
        BallMovement.instance.currentSpeed += speedScore;
    }
    public void Reeset()
    {
        PlayerPrefs.DeleteKey("HighScore"); 
    }
    
}
