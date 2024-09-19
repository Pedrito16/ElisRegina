using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    [SerializeField] Animator bolhaChatAnimator;
    [Header("Opções de escolha")]
    [SerializeField] int Choose;
    [SerializeField] GameObject sim, não;
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
        if (falaAtual >= falasMaximas && Input.GetKeyDown(KeyCode.E))
        {
            sim.SetActive(true);
            não.SetActive(true);
        }
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(0.45f);
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
