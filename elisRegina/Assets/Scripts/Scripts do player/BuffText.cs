using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuffText : MonoBehaviour
{
    //public Text buffDurationText;
    public TextMeshProUGUI buffDurationText;
    public int buffDuration = 180;
    [SerializeField] float timer;
    int segundo = 1;
    public bool ativador = false;
    public int binaryBool = 0;
    public Player player;
    private void Start()
    {
        buffDurationText.text = "Buff: ";
        binaryBool = PlayerPrefs.GetInt("binaryBool");
        if(binaryBool == 1)
        {
            buffDuration = PlayerPrefs.GetInt("buffDuration");
            buffDurationText.text = "Buff: " + buffDuration.ToString();
        }
        
    }
    void Update()
    {
        if(ativador == true)
        {
            binaryBool = 1;
        }
        else
        {
            binaryBool = 0;
        }
        PlayerPrefs.SetInt("binaryBool", binaryBool);
        timer += Time.deltaTime;
        if (timer >= segundo && ativador == true)
        {
            
            buffDuration -= 1;
            buffDurationText.text = "Buff: " + buffDuration.ToString();
            PlayerPrefs.SetInt("buffDuration", buffDuration);
            timer = 0f;
        }
        if (buffDuration <= 0)
        {
            player.buffNotActive = true;
            buffDurationText.text = "Buff: ";
            ativador = false;
            buffDuration = 180;
        }
    }
}

