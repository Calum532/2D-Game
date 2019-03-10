using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject HighScoresUI;
    public TextMeshProUGUI rushHighScore;
    public TextMeshProUGUI burstHighScore;
    public TextMeshProUGUI enduranceHighScore;
    private string Name = "Player";

    public void HighScores()
    {
        HighScoresUI.SetActive(true);
        menuUI.SetActive(false);

        rushHighScore.text = PlayerPrefs.GetString("RushName", Name) + ": " + PlayerPrefs.GetFloat("RushHighScore", 0).ToString("0");
        burstHighScore.text = PlayerPrefs.GetString("BurstName", Name) + ": " + PlayerPrefs.GetFloat("BurstHighScore", 0).ToString("0");
        enduranceHighScore.text = PlayerPrefs.GetString("EnduranceName", Name) + ": " + PlayerPrefs.GetFloat("EnduranceHighScore", 0).ToString("0");
    }

    public void Back()
    {
        menuUI.SetActive(true);
        HighScoresUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
