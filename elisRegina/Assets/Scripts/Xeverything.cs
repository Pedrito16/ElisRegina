using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Xeverything : MonoBehaviour
{
    public Text custoText, buffDurationText;
    public TextMeshProUGUI nomeText, descriçãoText, buffText;
    public string itemName, itemDescription, buffDescription;
    public int custo;
    public int buffDuration = 180;
    public Player player;
    [SerializeField] int contagemClique = 0;
    [SerializeField] float timer;
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descriçãoText.text = "";
        buffText.text = "";
        buffDurationText.text = "";
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
        nomeText.text = itemName;
        custoText.text = "Custo: " + custo.ToString();
        descriçãoText.text = itemDescription;
        buffText.text = buffDescription;

        contagemClique += 1;
        if (contagemClique >= 2 && player.dinheiro > custo)
        {
            Comprar();
            contagemClique = 0;
        }
        else if (contagemClique >= 2 && player.dinheiro < custo)
        {
            print("pobre!");
            contagemClique = 0;
        }

    }
    void Comprar()
    {
        player.dinheiro -= custo;
        timer += Time.deltaTime;
        buffDurationText.text = buffDuration.ToString();
            
        if (timer >= 1)
        {
            buffDuration -= 1;
            timer = 0;
        }

        if(buffDuration > 0)
        {
            player.moveSpeed *= 1.25f;
        }else if (buffDuration <= 0)
        {
            player.moveSpeed = 5;
        }
        
    }
}
