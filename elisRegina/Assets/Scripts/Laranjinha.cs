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
    [SerializeField] int contagemClique = 0;
    public BuffText bufftext;
    [Header("clique duplo ou normal")]
    float lastClickTime;
    float catchtime = 0.25f; 
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
        if(Time.time - lastClickTime < catchtime)
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
        }
        else if (bufftext.ativador == true)
        {
            print("variavel ja em uso");
        }
        if (bufftext.buffDuration > 0)
        {
            player.jumpStrenght *= 1.25f;
        }
    }
}
