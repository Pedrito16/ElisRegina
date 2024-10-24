using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Aposta : MonoBehaviour
{
    public Player player;
    public TMP_InputField betField;
    [SerializeField] int valorApostado;
    [SerializeField] Animator fadeOut;
    [SerializeField] GameObject apostaMenu;
    [SerializeField] GameObject canva;
    [SerializeField] NPCsimounão npc;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        npc = FindObjectOfType<NPCsimounão>();
    }
    private void Start()
    {
        apostaMenu.SetActive(false);
    }
    public void RightArrow()
    {
        if(valorApostado <= player.dinheiro)
        {
            valorApostado++;
            betField.text = valorApostado.ToString();
        }
        else
        {
            valorApostado = player.dinheiro;
            betField.text = valorApostado.ToString();
        }
    }
    public void LeftArrow()
    {
            valorApostado--;
            betField.text = valorApostado.ToString();

        if(valorApostado <= 0)
        {
            valorApostado = 0;
            betField.text = valorApostado.ToString();
        }
    }
    public void YesBTN()
    {
        StartCoroutine(trocarFase());
        BetInfo.valorAposta = valorApostado;
    }
    public void NoBTN()
    {
        StartCoroutine(trocarFase());
        BetInfo.valorAposta = 0;
    }
    public void SairBTN()
    {
        canva.SetActive(false);
        player.isTalking = false;
        npc.dito = false;
    }
    IEnumerator trocarFase()
    {
        fadeOut.SetTrigger("Apagar");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Truco");
    }
    void Update()
    {
        if (player.dinheiro < valorApostado)
        {
            valorApostado = player.dinheiro;
            betField.text = valorApostado.ToString();
        }
    }
    public void extrairNumero(string input)
    {
        if(int.TryParse(input, out valorApostado))
        {

        }
    }
}
public static class BetInfo 
{
    public static int valorAposta;
}
