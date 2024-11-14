using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class NPCsimounão : MonoBehaviour
{
    [Header("Coisas Visuais")]

    public GameObject eKeybind;
    public bool isCollidingPlayer;
    public GameObject bolhaChat;

    [Header("Falas do Personagem")]
    [SerializeField] private int falaAtual = -1;

    private int falasMaximas;

    [SerializeField] private string[] dialogo;

    public Player player;

    [SerializeField] private TextMeshProUGUI dialogoTexto;

    [SerializeField] private string nomeDoPersonagem;

    [SerializeField] private Text textoNomePersonagem;

    [SerializeField] private string falaNão;

    [SerializeField] private string falaSim;

    [SerializeField] private string falaSimSemDinheiro;    
    [SerializeField] Animator bolhaChatAnimator;
    [Header("Opções de escolha")]
    [SerializeField] int Choose;
    [SerializeField] GameObject sim, não;
    [SerializeField]public bool dito;
    [SerializeField] bool apertouNo;
    [SerializeField] bool apertouSim;
    [SerializeField] UnityEvent yesClick;
    [SerializeField] bool yesChat;
    void Start()
    {
        player = FindObjectOfType<Player>();
        sim.SetActive(false);
        não.SetActive(false);
        bolhaChat.SetActive(false);
        eKeybind.SetActive(false);
        //textoDialogo.text = "";
        dialogoTexto.text = "";
        textoNomePersonagem.text = "";
        falasMaximas = dialogo.Length;
    }


    void Update()
    {
        eKeybind.SetActive(isCollidingPlayer);
        // iniciador do dialogo
        
        if (Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && falaAtual < falasMaximas)
        {
            bolhaChat.SetActive(true);
            passandoDialogos();
            player.isTalking = true;
            //textoDialogo.text = dialogo[falaAtual];
            dialogoTexto.text = dialogo[falaAtual];
            textoNomePersonagem.text = nomeDoPersonagem;
        }
        // "reiniciador" do texto
        if (falaAtual >= falasMaximas && Input.GetKeyDown(KeyCode.E) && !dito)
        {
            sim.SetActive(true);
            não.SetActive(true);
            dito = true;
        }
        if(apertouNo == true && Input.GetKey(KeyCode.E))
        {
            bolhaChatAnimator.SetTrigger("Close");
            StartCoroutine(Close());
            apertouNo = false;
        }
        if(apertouSim && Input.GetKey(KeyCode.E))
        {
            if(player.dinheiro >= 10)
            {
                bolhaChatAnimator.SetTrigger("Close");
                StartCoroutine(Close());
                apertouSim = false;
                player.dinheiro -= 10;
                SceneManager.LoadScene("CutsceneAntesFavela");
            }
            else
            {
                bolhaChatAnimator.SetTrigger("Close");
                StartCoroutine(Close());
                apertouSim = false;
            }
        }
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(0.25f);
        bolhaChat.SetActive(false); 
        dialogoTexto.text = "";
        textoNomePersonagem.text = "";
        player.isTalking = false;
        falaAtual = -1;
        dito = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eKeybind.SetActive(false);
            isCollidingPlayer = false;
            bolhaChat.SetActive(false);
            player.isTalking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollidingPlayer = true;
        }
    }
    public void botaoSim()
    {
        bolhaChat.SetActive(false);
        sim.SetActive(false);
        não.SetActive(false);
        falaAtual = -1;
        if (yesChat)
        {
            yesClick.Invoke();
        }
    }
    public void botaoNão()
    {
        dialogoTexto.text = falaNão;
        sim.SetActive(false);
        não.SetActive(false);
        apertouNo = true;
    }
    public void YesGuarantee()
    {
        bolhaChat.SetActive(true);
        if(player.dinheiro >= 10)
        {
            dialogoTexto.text = falaSim;
        }
        else
        {
            dialogoTexto.text = falaSimSemDinheiro;
        }
        apertouSim = true;
    }
    void passandoDialogos()
    {
        if (falaAtual < falasMaximas)
        {
            falaAtual += 1;
            player.isTalking = true;
        }
    }
}
