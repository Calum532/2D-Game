using UnityEngine;
using TMPro;

public class EnduranceCountdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTMP;
    [SerializeField] private float mainTimer;
    private float countdownTimer = 3;
    public static float cTimer;

    public GameObject scoreUI;
    public static float timer; 
    private bool canCount = true;
    private bool finished = false;
    private bool countdown = false;

    public float totalTime;
    public float totalTimeElapsed;

    public Animator camAnim1;
    public Animator camAnim2;
    public Animator camAnim3;
    public Animator camAnim4;

    public void addTime()
    {
        if(GetComponent<EnduranceScore>().targetsDestroyed <= 10)
        {
            timer = timer + 1f;
            camAnim1.SetTrigger("1SecAdded");
        }
        else if (GetComponent<EnduranceScore>().targetsDestroyed <= 15)
        {
            timer = timer + 0.8f;
            camAnim2.SetTrigger("1SecAdded");
        }
        else if (GetComponent<EnduranceScore>().targetsDestroyed <= 20)
        {
            timer = timer + 0.5f;
            camAnim3.SetTrigger("1SecAdded");
        }
        else
        {
            timer = timer + 0.2f;
            camAnim4.SetTrigger("1SecAdded");
        }
    }

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
            totalTime += Time.deltaTime;
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
            totalTimeElapsed = totalTime;
            finished = true;
            scoreUI.SetActive(true);
            Pause.gameIsPaused = true;
            GetComponent<EnduranceScore>().calculateAccuracy();
            GetComponent<EnduranceScore>().setTimeElapsed();
            GetComponent<EnduranceScore>().calculateScore();
        }
    }
}
