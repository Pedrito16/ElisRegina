using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using System;

public class Xeverything : MonoBehaviour
{
    public Text custoText;
    public TextMeshProUGUI nomeText, descriçãoText, buffText;
    public string itemName, itemDescription, buffDescription;
    public int custo;
    public Player player;
    [SerializeField] int contagemClique = 0;
    [SerializeField] float timer;
    int segundo = 2;
    public BuffText bufftext;
    bool resetClick = false;
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descriçãoText.text = "";
        buffText.text = "";
        
    }


    void Update()
    {
        if (player.dinheiro > custo)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }
        else if (player.dinheiro < custo)
        {
            custoText.GetComponent<Text>().color = Color.red;
        }
        timer += Time.deltaTime;
        if (timer > segundo)
        {
            timer = 0;
            contagemClique = 0;
        }
        
    }
    public void OnClick()
    {
        nomeText.text = itemName;
        custoText.text = "Custo: " + custo.ToString();
        descriçãoText.text = itemDescription;
        buffText.text = buffDescription;
        contagemClique++;
        resetClick = true;
        if (contagemClique >= 2 && player.dinheiro >= custo)
        {
            Comprar();
            contagemClique = 0;
        }
        else if (contagemClique >= 2 && player.dinheiro < custo)
        {
            print("pobre!");
            contagemClique = 0;
        }
        {

        }
        
    }
    void Comprar()
    {
        player.dinheiro -= custo;
        player.buffNotActive = false;

        if (bufftext.ativador == false)
        {
            bufftext.ativador = true;
        }else if(bufftext.ativador == true)
        {
            print("variavel ja em uso");
        }
        if (bufftext.buffDuration > 0)
        {
            player.moveSpeed *= 1.25f;
        }
        
    }
}
