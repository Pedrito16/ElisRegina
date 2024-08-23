using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Life : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    void Update()
    {
        lifeText.text = "Life: " + GetComponent<Player>().life;
        
    }
}
