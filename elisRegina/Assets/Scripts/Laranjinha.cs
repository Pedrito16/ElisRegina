using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Laranjinha : MonoBehaviour
{
    public Text custoText;
    public TextMeshProUGUI nomeText, descriçãoText, buffText;
    public string itemName, itemDescription, buffDescription;
    public int custo;
    public Player player;
    public BuffText bufftext;
    public AudioSource BuyItem;
    [Header("Verificação De clique")]
    public Xeverything xeverything;
    public Hamburguer hamburguer;
    public HamburguerDourado hamburguerG;
    public bool isClicking;
    [Header("clique duplo ou normal")]
    float lastClickTime;
    float catchtime = 0.25f;
    private void Awake()
    {
        xeverything = GetComponent<Xeverything>();
        hamburguerG = GetComponent<HamburguerDourado>();
        hamburguer = GetComponent<Hamburguer>();
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
            hamburguer.isClicking = false;
            xeverything.isClicking = false;
            hamburguerG.isClicking = false; 
        }
        if (player.dinheiro >= custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }
        else if (player.dinheiro <= custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.red;
        }
        if (Time.time - lastClickTime < catchtime)
        {
            lastClickTime = 0;
            if(player.dinheiro >= custo)
            {
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
        
        BuyItem.Play();
        if (BuffTimer.laranjinhaAtivo == false)
        {
            BuffTimer.laranjinhaAtivo = true;
        }
        else if (BuffTimer.laranjinhaAtivo == true)
        {
            print("variavel ja em uso");
        }
    }
}
