using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, blur;
    string activeSceneName;
    [SerializeField] Animator pauseAnimator;
    public bool Ativador = false;
    [SerializeField] GameObject ReturnBTN;
    void Start()
    {
        if(ReturnBTN != null)
        {
            ReturnBTN.SetActive(false);
        }
        pauseMenu.SetActive(false);
        blur.SetActive(false);
        activeSceneName = SceneManager.GetActiveScene().name;
        pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    private void Awake()
    {
        pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Ativador == false)
        {
            pauseMenu.SetActive(true);
            blur.SetActive(true);
            if (ReturnBTN != null)
            {
                ReturnBTN.SetActive(true);
            }
            Time.timeScale = 0;
            PauseClass.Paused = true;
            Ativador = true;
        } else if (Input.GetKeyDown(KeyCode.Escape) && Ativador == true)
        {
            StartCoroutine(CloseAnimation());
        }
    }
    IEnumerator Open()
    {
        yield return new WaitForSecondsRealtime(0.20f);
        Time.timeScale = 0;
        Ativador = true;
    }
    IEnumerator CloseAnimation()
    {
        pauseAnimator.SetTrigger("Close");
        yield return new WaitForSecondsRealtime(0.35f);
        pauseMenu.SetActive(false);
        blur.SetActive(false);
        Ativador = false;
        Time.timeScale = 1;
        PauseClass.Paused = false;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        StartCoroutine(CloseAnimation());
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
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
public static class PauseClass
{
    public static bool Paused;
}