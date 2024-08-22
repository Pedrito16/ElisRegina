using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hamburguer : MonoBehaviour
{
    public Text custoText;
    public TextMeshProUGUI nomeText, descri��oText, buffText;
    public string itemName, itemDescription, buffDescription;
    public int custo;
    public Player player;
    [SerializeField] int contagemClique = 0;
    bool resetClick = false;
    [SerializeField] float timer;
    int segundo = 1;
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descri��oText.text = "";
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
        timer += Time.deltaTime;
        if(timer > segundo )
        {
            timer = 0;
        }
        if (timer >= segundo && resetClick == true)
        {
            contagemClique = 0;
            timer = 0;
            resetClick = false;
        }
    }
    public void OnClick()
    {
        nomeText.text = itemName;
        custoText.text = "Custo: " + custo.ToString();
        descri��oText.text = itemDescription;
        buffText.text = buffDescription;
        resetClick = true;
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
