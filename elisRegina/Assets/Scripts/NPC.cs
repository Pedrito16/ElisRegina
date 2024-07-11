using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    [Header("Coisas Visuais")]

    public GameObject eKeybind;
    public bool isCollidingPlayer;

    [Header("Falas do Personagem")]
    private int falaAtual = 0;
    private int falasMaximas;
    [SerializeField] private string[] dialogo;
    [SerializeField] private Text textoDialogo;
    void Start()
    {
        eKeybind.SetActive(false);
        falasMaximas = dialogo.Length;
        textoDialogo.text = "";
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true)
        {
            textoDialogo.text = dialogo[falaAtual];
            passandoDialogos();
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
            falaAtual++;

        }else if(falaAtual > falasMaximas)
        {
            textoDialogo.text = "";
        }

    }
}
