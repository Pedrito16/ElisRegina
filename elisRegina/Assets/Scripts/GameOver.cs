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
    float timer2;
    float timerLimit = 1;
    [SerializeField] float timerLimit2 = 15f;
    [SerializeField] AudioSource mainSoundtrack, rainSound;
    [SerializeField] AudioClip rainSFX;
    bool ativador = true;
    Vector3 playerPos;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        rainSound.clip = rainSFX;
    }
    void Start()
    {
        canvaPrincipal = GameObject.FindWithTag("HUD");
        telaMorte.SetActive(isActive);
        particula.SetActive(false);
        textoRessurgir.SetActive(false);
        isActive = false;
        playerPos = player.gameObject.transform.position;
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
            particula.transform.position = new Vector3(playerPos.x, playerPos.y + 1f, playerPos.z);
            mainSoundtrack.Pause();
            if (rainSound.gameObject.activeSelf && ativador)
            {
                rainSound.PlayOneShot(rainSFX);
                ativador = false;
            }
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
}
