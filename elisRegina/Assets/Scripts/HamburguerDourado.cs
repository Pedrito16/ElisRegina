using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class HamburguerDourado : MonoBehaviour
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
    public Xeverything xeverything;
    public Hamburguer hamburguer;
    public Laranjinha laranjinha;
    public bool isClicking = false;
    private void Awake()
    {
        xeverything = GetComponent<Xeverything>();
        laranjinha = GetComponent<Laranjinha>();
        hamburguer = GetComponent<Hamburguer>();
        player = FindObjectOfType<Player>();
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
        
    }
    public void OnClick()
    {
        isClicking = true;
        if(isClicking == true)
        {
            xeverything.isClicking = false;
            laranjinha.isClicking = false;
            hamburguer.isClicking = false;
        }
        if (player.dinheiro > custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }else if(player.dinheiro <= custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.red;
        }
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
            lastClickTime = Time.time;
            nomeText.color = Color.yellow;
            nomeText.text = itemName;
            custoText.text = "Custo: " + custo.ToString();
            descriçãoText.text = itemDescription;
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

