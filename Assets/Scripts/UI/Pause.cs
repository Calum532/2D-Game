﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    private bool canCount = true;
    private bool finished = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        FindObjectOfType<AudioManager>().Play("Click");
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
