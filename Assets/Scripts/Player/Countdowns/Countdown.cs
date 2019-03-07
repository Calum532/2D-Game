using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTMP;
    [SerializeField] private float mainTimer;
    private float countdownTimer = 3;

    public GameObject scoreUI;
    public static float timer;
    public static float cTimer;
    private bool canCount = true;
    private bool finished = false;
    private bool countdown = false;


    private void Start()
    {
        timer = mainTimer;
        cTimer = countdownTimer;
    }

    private void Update()
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
            timer -= Time.deltaTime;
            countdownTMP.text = timer.ToString("0.00");
        }
        else if (finished == true)
        {
            canCount = false;
        }

        if (timer <= 5f)
        {
            countdownTMP.faceColor = Color.red;
        }

        if (timer <= 0f)
        {
            finished = true;
            scoreUI.SetActive(true);
            Pause.gameIsPaused = true;
            GetComponent<Score>().calculateAccuracy();
            GetComponent<Score>().calculateScore();
        }
    }
}
