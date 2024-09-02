using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hamburguer : MonoBehaviour
{
    public Text custoText;
    public TextMeshProUGUI nomeText, descriçãoText, buffText;
    public string itemName, itemDescription, buffDescription;
    public int custo;
    public Player player;
    [SerializeField] int contagemClique = 0;
    [SerializeField] float timer;
    public AudioSource buyItem;
    float catchTime = 0.25f;
    float lastClickTime = 0;
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descriçãoText.text = "";
        buffText.text = "";
    }

    
    void Update()
    {
        if(player.dinheiro > custo)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }else if (player.dinheiro < custo)
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
        if (player.life < 3)
        {
            buyItem.Play();
            player.life += 1;
            player.dinheiro -= custo;
        }
        else if(player.life > 3)
        {
            player.dinheiro += custo;
        }        
    }
}
