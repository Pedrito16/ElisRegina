using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DinheiroTexto : MonoBehaviour
{
    public TextMeshProUGUI dinheiroText;
    void Update()
    {
        dinheiroText.text = GetComponent<Player>().dinheiro.ToString();
    }
}
