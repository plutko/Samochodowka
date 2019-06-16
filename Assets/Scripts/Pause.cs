using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenu;

    private string menuToGoBack = "";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void EnterOptions(string buttonName)
    {
        menuToGoBack = buttonName;
    }

    public void Back()
    {
        if (menuToGoBack == "pauseMenu")
        {
            pauseMenu.SetActive(true);
        }
        else if (menuToGoBack == "mainMenu")
        {
            mainMenu.SetActive(true);
        }
    }
}