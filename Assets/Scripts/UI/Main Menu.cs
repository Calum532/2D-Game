using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject ModeSelectUI;


    public void ModeSelect()
    {
        ModeSelectUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void Back()
    {
        menuUI.SetActive(true);
        ModeSelectUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
