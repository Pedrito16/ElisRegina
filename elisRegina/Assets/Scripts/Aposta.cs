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
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        apostaMenu.SetActive(false);
    }
    public void YesBTN()
    {
        StartCoroutine(trocarFase());
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
