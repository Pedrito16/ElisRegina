using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Player player;
    public GameObject gameOverText;


    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if(player != null && player.life <= 0 ) 
        {
            Debug.Log("morreu??");
            gameOver();

        }
        if (Input.GetButtonDown("Respawn"))
        {
            

        }
    }
    void gameOver()
    {
        gameObject.SetActive(true);

    }
}
