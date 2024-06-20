using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverText;


    void Start()
    {
        gameOverText.SetActive(false);
    }
    void Update()
    {
        if(player.GetComponent<Player>().life = 0)
        {
            gameOver();

        }
        if (Input.GetButtonDown("Respawn"))
        {


        }
    }
    void gameOver()
    {
        gameOverText.SetActive(true);

    }
}
