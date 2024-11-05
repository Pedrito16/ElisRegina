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
    public AudioSource buyItem;
    float catchTime = 0.25f;
    float lastClickTime = 0;
    [SerializeField] Life life;
    [Header("Verificação De clique")]
    public Xeverything xeverything;
    public HamburguerDourado hamburguerG;
    public Laranjinha laranjinha;
    public bool isClicking = false;
    private void Awake()
    {
        life = FindObjectOfType<Life>();
        xeverything = GetComponent<Xeverything>();
        hamburguerG = GetComponent<HamburguerDourado>();
        laranjinha = GetComponent<Laranjinha>();
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        nomeText.text = "";
        custoText.text = "";
        descriçãoText.text = "";
        buffText.text = "";
    }

    public void OnClick()
    {
        isClicking = true;
        if(isClicking == true)
        {
            laranjinha.isClicking = false;
            xeverything.isClicking = false;
            hamburguerG.isClicking = false;
        }
        if (player.dinheiro >= custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.green;
        }
        else if (player.dinheiro < custo && isClicking == true)
        {
            custoText.GetComponent<Text>().color = Color.red;
        }
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
            life.recoverLife = true;
            player.dinheiro -= custo;
        }
        else if(player.life > 3)
        {
            player.dinheiro += custo;
        }        
    }
}
