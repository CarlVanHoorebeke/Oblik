using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject options;
    [SerializeField] Text highScore;

    void Awake()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }    
    public void Resume()
    {
        options.SetActive(false);
        main.SetActive(true);
    }
    public void Reeset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
