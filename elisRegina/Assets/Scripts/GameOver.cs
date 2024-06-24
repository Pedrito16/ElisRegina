using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public GameObject gameOverText;


    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
  
    
}
