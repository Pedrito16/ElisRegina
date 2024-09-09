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
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
            BuffTimer.buffDuration = 180;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //StartCoroutine(Morreu());

        }
    }
    IEnumerator Morreu()
    {
        BuffTimer.morreu = true;
        yield return new WaitForSeconds(2);
        BuffTimer.morreu = false;
    }    
}
