using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTMP;
    [SerializeField] private float mainTimer;

    public GameObject scoreUI;
    public static float timer;
    private bool canCount = true;
    private bool finished = false;


    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        if (finished == false)
        {
            timer -= Time.deltaTime;
            countdownTMP.text = timer.ToString("0.00");
        }
        else if (finished == true)
        {
            canCount = false;
        }

        if (timer <= 0f)
        {
            Debug.Log("Time's up!");
            finished = true;
            countdownTMP.faceColor = Color.red;
            scoreUI.SetActive(true);
            Time.timeScale = 0f;
            //PauseMenu.gameIsPaused = true;
        }
    }
}
