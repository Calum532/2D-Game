using UnityEngine;
using TMPro;

public class BurstTimer : MonoBehaviour
{
    private float countdownTimer = 3;
    public static float cTimer;
    private bool countdown = false;

    public TextMeshProUGUI timerText;
    public static float finishTime;
    private bool finished;
    private float t;
    public GameObject scoreUI;

    private void Start()
    {
        cTimer = countdownTimer;
    }

    void Update()
    {
        if (countdown == false)
        {
            Pause.gameIsPaused = true;
            cTimer -= Time.deltaTime;
        }

        if (cTimer <= 0f)
        {
            Pause.gameIsPaused = false;
            countdown = true;
        }

        if (finished == false & countdown == true)
        {
            t += Time.deltaTime;
            timerText.text = t.ToString("0.00");
        }

        if (GetComponent<BurstScore>().targetsDestroyed >= 40)
        {
            finishTime = t;
            finished = true;
            timerText.color = Color.red;
            scoreUI.SetActive(true);
            Pause.gameIsPaused = true;
            GetComponent<BurstScore>().calculateAccuracy();
            GetComponent<BurstScore>().calculateScore();
            GetComponent<BurstScore>().setFinishTime();
        }
    }
}
