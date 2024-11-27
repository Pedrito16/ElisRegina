using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NPC : MonoBehaviour
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

    [SerializeField] Animator bolhaChatAnimator;
    
    void Start()
    {
        bolhaChat.SetActive(false);
        eKeybind.SetActive(false);
        //textoDialogo.text = "";
        dialogoTexto.text = "";
        textoNomePersonagem.text = "";
        falasMaximas = dialogo.Length;
        bolhaChatAnimator = bolhaChat.GetComponent<Animator>();
    }

   
    void Update()
    {
        eKeybind.SetActive(isCollidingPlayer);
        // iniciador do dialogo 
        if(Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && falaAtual < falasMaximas || Input.GetMouseButtonDown(0) && isCollidingPlayer == true && falaAtual < falasMaximas)
        {
            bolhaChat.SetActive(true);
            passandoDialogos();
            player.isTalking = true;
            //textoDialogo.text = dialogo[falaAtual];
            dialogoTexto.text = dialogo[falaAtual];
            textoNomePersonagem.text = nomeDoPersonagem;
        }
        // "reiniciador" do texto
        if (falaAtual >= falasMaximas && Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) && falaAtual >= falasMaximas)
        {
            //textoDialogo.text = "";
            bolhaChatAnimator.SetTrigger("Close");
            StartCoroutine(Close());
        }
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(0.25f);
        bolhaChat.SetActive(false); dialogoTexto.text = "";
        textoNomePersonagem.text = "";
        player.isTalking = false;
        falaAtual = -1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eKeybind.SetActive(false);
            isCollidingPlayer = false;
            StartCoroutine(Close());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollidingPlayer = true;
        }
    }
    void passandoDialogos()
    {
        if(falaAtual < falasMaximas)
        {
            falaAtual += 1;
            player.isTalking = true;
        }
    }
}
