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


    [SerializeField] private TextMeshProUGUI dialogoTexto;

    [SerializeField] private string nomeDoPersonagem;

    [SerializeField] private Text textoNomePersonagem;
    
    void Start()
    {
        bolhaChat.SetActive(false);
        eKeybind.SetActive(false);
        //textoDialogo.text = "";
        dialogoTexto.text = "";
        textoNomePersonagem.text = "";
        falasMaximas = dialogo.Length;
       

    }

   
    void Update()
    {
        // iniciador do dialogo
        if(Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && falaAtual < falasMaximas) 
        {
            bolhaChat.SetActive(true);
            passandoDialogos();
            //textoDialogo.text = dialogo[falaAtual];
            dialogoTexto.text = dialogo[falaAtual];
            textoNomePersonagem.text = nomeDoPersonagem;

        }
        // "reiniciador" do texto
        if (falaAtual >= falasMaximas && Input.GetKeyDown(KeyCode.E))
        {
            //textoDialogo.text = "";
            dialogoTexto.text = "";
            textoNomePersonagem.text = "";
            bolhaChat.SetActive(false);
            falaAtual = -1;
        }
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
    void passandoDialogos()
    {
        if(falaAtual < falasMaximas)
        {
            falaAtual += 1;

        }
       

    }
}
