using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuPanel : MonoBehaviour
{
   public static bool pauseGame = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
    }
}
