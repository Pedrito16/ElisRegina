using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HamburguerDourado : MonoBehaviour
{
    public Text custoText;
    public TextMeshProUGUI nomeText, descri��oText, buffText;
    public string itemName, itemDescription, buffDescription;
    public int custo;
    public Player player;
    public SFX SFXscript;
    public AudioSource buyItem;
    public BuffText bufftext;
    float lastClickTime = 0;
    float catchTime = 0.25f;
    bool isClicking = false;
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descri��oText.text = "";
        buffText.text = "";
    }

    void Update()
    {
        if (player.dinheiro > custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }
        else if (player.dinheiro < custo && isClicking == true)
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
                player.dinheiro -= custo;
            }else if(player.dinheiro <= custo)
            {
                Debug.Log("Sem dinheiro");  
            }
            print("clique duplo");
        }
        else
        {
            isClicking = true;
            lastClickTime = Time.time;
            nomeText.color = Color.yellow;
            nomeText.text = itemName;
            custoText.text = "Custo: " + custo.ToString();
            descri��oText.text = itemDescription;
            buffText.text = buffDescription;
            Debug.Log("clique solo");
        }
    }
    void Comprar()
    {
        Dourado.playerDourado = true;
    }
}

public static class Dourado 
{
    public static bool playerDourado = false;
}
