using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string activeSceneName;
    public bool Ativador = false;
    void Start()
    {
        pauseMenu.SetActive(false);
        activeSceneName = SceneManager.GetActiveScene().name;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Ativador == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Ativador = true;
        } else if (Input.GetKeyDown(KeyCode.Escape) && Ativador == true)
        {
          Ativador = false;
          Time.timeScale = 1;
          pauseMenu.SetActive(false);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        print("clicou");
    }
    public void Restart()
    {
        SceneManager.LoadScene(activeSceneName);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
