using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI targets;
    public TextMeshProUGUI targetsUI;
    public float targetsDestroyed = 0;

    public TextMeshProUGUI clicksTotal;
    public float clicksMissed = 0;
    public float clickCount = 0;

    public TextMeshProUGUI accuracy;
    public float calcAccuracy = 100f;

    public TextMeshProUGUI score;
    public int totalScore = 0;

    void Update()
    {
        //calculateAccuracy();
        clickCount = targetsDestroyed + clicksMissed;
        targets.text = targetsDestroyed.ToString();
        targetsUI.text = targetsDestroyed.ToString();
        clicksTotal.text = clickCount.ToString();
        accuracy.text = calcAccuracy.ToString("00.0") + "%";
        score.text = totalScore.ToString();
    }

    public void targetsDestroyedCount()
    {
        //+1 to targets destroyed
        targetsDestroyed = targetsDestroyed + 1;
    }

    public void clicksMissedCount()
    {
        //+1 to clicks missed
        clicksMissed = clicksMissed + 1;
    }

    public void calculateAccuracy()
    {
        //calcAccuracy = targetsDestroyed / clickCount * 100;
        calcAccuracy = (targetsDestroyed/clickCount) * 100;
    }
}
