using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuffText : MonoBehaviour
{
    //public Text buffDurationText;
    public TextMeshProUGUI buffDurationText;
    //public int buffDuration = 180;
    [SerializeField] float timer;
    int segundo = 1;
    public bool ativador = false;
    public Player player;
    private void Start()
    {
        buffDurationText.text = "Buff: ";
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= segundo && ativador == true)
        {
            
            BuffTimer.buffDuration -= 1;
            buffDurationText.text = "Buff: " + BuffTimer.buffDuration.ToString();
            timer = 0f;
        }
        if (BuffTimer.buffDuration <= 0)
        {
            player.buffNotActive = true;
            buffDurationText.text = "Buff: ";
            ativador = false;
            BuffTimer.buffDuration = 180;
        }
    }
}
public static class BuffTimer
{
    public static int buffDuration = 180;
}
