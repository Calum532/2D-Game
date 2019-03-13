using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject levelCompleteUI;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        levelCompleteUI.SetActive(false);
        Pause.gameIsPaused = false;
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void resetHighScore()
    {
        PlayerPrefs.DeleteAll();
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
