using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject highScoresUI;
    public GameObject aboutUI;
    public TextMeshProUGUI rushHighScore;
    public TextMeshProUGUI burstHighScore;
    public TextMeshProUGUI enduranceHighScore;
    private string Name = "Player";

    public void HighScores()
    {
        highScoresUI.SetActive(true);
        menuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Click");

        rushHighScore.text = PlayerPrefs.GetString("RushName", Name) + ": " + PlayerPrefs.GetFloat("RushHighScore", 0).ToString("0");
        burstHighScore.text = PlayerPrefs.GetString("BurstName", Name) + ": " + PlayerPrefs.GetFloat("BurstHighScore", 0).ToString("0");
        enduranceHighScore.text = PlayerPrefs.GetString("EnduranceName", Name) + ": " + PlayerPrefs.GetFloat("EnduranceHighScore", 0).ToString("0");
    }

    public void About()
    {
        menuUI.SetActive(false);
        aboutUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void Back()
    {
        menuUI.SetActive(true);
        highScoresUI.SetActive(false);
        aboutUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
