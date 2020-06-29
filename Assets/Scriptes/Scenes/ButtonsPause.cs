using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private GameObject Player;


    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        PauseMenuUI.SetActive(false);
        Player.GetComponent<CharacterControllerScript>().enabled = true;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Player.GetComponent<CharacterControllerScript>().enabled = false;
        GameIsPaused = true;
    }
}
