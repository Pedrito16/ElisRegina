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
    public SFX SFXscript;
    public AudioSource buyItem;
    public BuffText bufftext;
    float lastClickTime = 0;
    float catchTime = 0.25f;
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
    }
    public void OnClick()
    {
        if (Time.time - lastClickTime < catchTime)
        {
            lastClickTime = 0;
            if (player.dinheiro >= custo)
            {
                buyItem.Play();
                Comprar();
            }
            print("clique duplo");
        }
        else
        {
            lastClickTime = Time.time;
            nomeText.text = itemName;
            custoText.text = "Custo: " + custo.ToString();
            descriçãoText.text = itemDescription;
            buffText.text = buffDescription;
            Debug.Log("clique solo");
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
