using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botao : MonoBehaviour
{
    public string sceneName = "Cena 3(Pedro)";
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
