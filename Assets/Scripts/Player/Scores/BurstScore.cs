using UnityEngine;
using TMPro;

public class BurstScore : MonoBehaviour
{
    public TextMeshProUGUI targetsUI;
    public float targetsDestroyed = 0;

    public TextMeshProUGUI finishTime;
    public float finishBonus;

    public TextMeshProUGUI clicksTotal;
    public float clickCount = 0;

    public TextMeshProUGUI accuracy;
    public TextMeshProUGUI accuracyBonusText;
    public float calcAccuracy = 100f;
    public float accuracyBonus;

    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public float totalScore = 0;

    private string Name = "Player";

    public GameObject newHighscoreUI;

    void Start()
    {
        highScore.text = PlayerPrefs.GetString("BurstName", Name) +": "+PlayerPrefs.GetFloat("BurstHighScore", 0).ToString("0");
    }

    void Update()
    {
        calculateScore();
        targetsUI.text = targetsDestroyed.ToString();
        clicksTotal.text = clickCount.ToString();
        accuracy.text = calcAccuracy.ToString("00.0") + "%";
        score.text = totalScore.ToString("0");
    }

    public void setHighScoreHoldersName(string Name)
    {
        PlayerPrefs.SetString("BurstName", Name);
    }

    public void resetHighScore()
    {
        PlayerPrefs.DeleteAll();
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void setFinishTime()
    {
        finishTime.text = BurstTimer.finishTime.ToString("0.00");
        finishBonus = (60 - BurstTimer.finishTime) * 100;
    }

    public void calculateScore()
    {
        totalScore = finishBonus * accuracyBonus;

        if(totalScore > PlayerPrefs.GetFloat("BurstHighScore", 0))
        {
            PlayerPrefs.SetFloat("BurstHighScore", totalScore);
            highScore.text = Name+": "+totalScore.ToString("0");
            newHighscoreUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("NewHighScore!");
        }
    }

    public void targetsDestroyedCount()
    {
        //+1 to targets destroyed
        targetsDestroyed = targetsDestroyed + 1;
    }

    public void clicksCount()
    {
        //+1 to clickCount
        clickCount = clickCount + 1;
    }

    public void calculateAccuracy()
    {
        calcAccuracy = (targetsDestroyed/clickCount) * 100;

        if (calcAccuracy >= 100)
        {
            accuracyBonus = 3f;
            accuracyBonusText.text = "x3";
        }
        else if (calcAccuracy >= 90)
        {
            accuracyBonus = 2f;
            accuracyBonusText.text = "x2";
        }
        else if (calcAccuracy >= 75)
        {
            accuracyBonus = 1.5f;
            accuracyBonusText.text = "x1.5";
        }
        else if (calcAccuracy >= 50)
        {
            accuracyBonus = 1f;
            accuracyBonusText.text = "x1";
        }
        else
        {
            accuracyBonus = 0.5f;
            accuracyBonusText.text = "x0.5";
        }
    }
}
