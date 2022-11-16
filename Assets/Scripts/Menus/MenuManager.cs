using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("Fullscreen", 1) == 1) Screen.fullScreen = true;
        else Screen.fullScreen = false;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        
        if (isFullscreen) PlayerPrefs.SetInt("Fullscreen", 1);
        else PlayerPrefs.SetInt("Fullscreen", 0);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}