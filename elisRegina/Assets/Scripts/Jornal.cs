using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Jornal : MonoBehaviour
{
    public GameObject InteractionE;
    public bool isCollidingPlayer;
    [Header("Jornal UI")]
    public GameObject JornalUI;
    public TextMeshProUGUI textoJornalText;
    public string textoJornal;
    public bool ativado;
    void Start()
    {
        JornalUI.SetActive(false);
        InteractionE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textoJornalText.text = textoJornal;
        if (Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && ativado == false)
        {
            JornalUI.SetActive(true);
            ativado = true;
        }else if (Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && ativado == true)
        {
            JornalUI.SetActive(false);
            ativado = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractionE.SetActive(true);
            isCollidingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            InteractionE.SetActive(false);
            isCollidingPlayer = false;
            JornalUI.SetActive(false);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
