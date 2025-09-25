using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class LogicSCript : MonoBehaviour
{
    //initialised the variables needed
    public int playerScore;
    public Text scoreText;
    public TMP_Text highestScoreText;
    public GameObject gameOverScreen;
    public int highestScore;
    private readonly List<int> scoreList = new();

    private bool isPaused = false;

    private bool isGameOver = false;


    [ContextMenu("Increase Score:")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > GetHighestScore())
        {
            highestScoreText.SetText(playerScore.ToString());
        }

    }
    public void StoreScore()
    {
        scoreList.Add(highestScore);
        SaveHighestScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameOver = true;
        highestScore = playerScore;
        StoreScore();
        AudioManager.instance.musicSource.Stop();
        gameOverScreen.SetActive(true);
    }

    public int GetHighestScore()
    {
        return PlayerPrefs.GetInt("HighestScore", 0);
    }

    private void SaveHighestScore()
    {
        int currentHighest = GetHighestScore();
        if (highestScore > currentHighest)
        {
            PlayerPrefs.SetInt("HighestScore", highestScore);
            PlayerPrefs.Save(); // Force save to disk
        }
    }

    public void PrintHighestScore()
    {
        highestScoreText.SetText(GetHighestScore().ToString());
    }

    void Start()
    {
        PrintHighestScore();
    }

    public void TogglePause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void ToggleResume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void ToggleMainMenu()
    {
        SceneManager.LoadScene(0);
        if (AudioManager.instance.musicSource.isPlaying)
        {
            AudioManager.instance.musicSource.Stop();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool getIsPaused()
    {
        return isPaused;
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

}
