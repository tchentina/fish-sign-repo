using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class Buttons : MonoBehaviour
{
    public void changeScene()
    {
        Debug.Log("Changing to Game scene.");
        SceneManager.LoadScene("BeachSide");
    }

    public void quitGame()
    {
        Debug.Log("Quit has been clicked.");
        Application.Quit();
    }
}
