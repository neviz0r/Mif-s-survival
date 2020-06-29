using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {

    }

    public void Options()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(6, true);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(4, true);
    }

    public void Normal()
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
