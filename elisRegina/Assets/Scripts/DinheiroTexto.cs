using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DinheiroTexto : MonoBehaviour
{
    public Text dinheiroText;
    void Update()
    {
        dinheiroText.text = "Cruzeiros: " + GetComponent<Player>().dinheiro;
    }
}
