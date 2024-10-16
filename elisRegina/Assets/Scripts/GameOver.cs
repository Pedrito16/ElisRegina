using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject telaMorte, textoRessurgir, particula, canvaPrincipal;
    Player player;
    bool isActive;
    public Animator thunder;
    float timer;
    float timerLimit = 1;
    [SerializeField ]float timer2, timerLimit2 = 15f;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        canvaPrincipal = GameObject.FindWithTag("HUD");
        telaMorte.SetActive(isActive);
        particula.SetActive(false);
        textoRessurgir.SetActive(false);
        isActive = false;
    }
    void Update()
    {
        if(player.life <= 0)
        {
            telaMorte.SetActive(true);
            isActive = true;
            particula.SetActive(true);
            thunder.gameObject.SetActive(true);
            canvaPrincipal.SetActive(false);
        }
        timer += Time.deltaTime;
        if(timer >= timerLimit && isActive) 
        {
            textoRessurgir.SetActive(!textoRessurgir.activeSelf);
            timer = 0f;
        }
        if(isActive)
        {
            timer2 += Time.deltaTime;
        }
        if(timer2 >= timerLimit2 && isActive)
        {
            thunder.SetTrigger("Ativar");
            timer2 = 0f;
        }
        if (Input.GetButtonDown("Respawn") && isActive)
        {
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
            BuffTimer.buffDuration = 180;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator morteTextPiscar()
    {
        
        textoRessurgir.SetActive(true);
        yield return new WaitForSeconds(1);
        textoRessurgir.SetActive(false);
    }    
}
