using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public CarController playerCar1;
    public CarController playerCar2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerCar1.ResetCarRotation();
        }

        if (Input.GetButtonDown("reset2"))
        {
            playerCar2.ResetCarRotation();
        }
    }

    public void OnePlayerBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}