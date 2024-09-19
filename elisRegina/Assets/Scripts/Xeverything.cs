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
    [Header("Verificação De clique")]
    public Hamburguer hamburguer;
    public HamburguerDourado hamburguerG;
    public Laranjinha laranjinha;
    public bool isClicking;
    private void Awake()
    {
        hamburguer = GetComponent<Hamburguer>();
        hamburguerG = GetComponent<HamburguerDourado>();
        laranjinha = GetComponent<Laranjinha>();
    }
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descriçãoText.text = "";
        buffText.text = "";
    }


    void Update()
    {
        if (player.dinheiro >= custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }
        else if (player.dinheiro <= custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.red;
        }
    }
    public void OnClick()
    {
        isClicking = true;
        if(isClicking)
        {
            laranjinha.isClicking = false;
            hamburguer.isClicking = false;
            hamburguerG.isClicking = false;
        }
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
            nomeText.color = Color.white;
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
        
        if (BuffTimer.xtudoAtivado == false)
        {
            BuffTimer.xtudoAtivado = true;
        }else if(BuffTimer.xtudoAtivado == true)
        {
            print("variavel ja em uso");
        }
    }
}
