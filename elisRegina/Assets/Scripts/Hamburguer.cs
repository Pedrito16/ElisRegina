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
        nomeText.text = itemName;
        custoText.text = "Custo: " + custo.ToString();
        descriçãoText.text = itemDescription;
        buffText.text = buffDescription;

        contagemClique += 1;
        if(contagemClique >= 2 && player.dinheiro > custo)
        {
            Comprar();
            contagemClique = 0;
        } else if(contagemClique >= 2 && player.dinheiro < custo) 
        {
            print("pobre!");
            contagemClique = 0;
        }

    }
    void Comprar()
    {
        player.dinheiro -= custo;
        if(player.life < 3)
        {
            player.life += 1;
        }
    }
}
