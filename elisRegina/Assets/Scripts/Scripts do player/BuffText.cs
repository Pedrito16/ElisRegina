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
    public int buffDuration;
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
        buffDuration = BuffTimer.buffDuration;
        timer += Time.deltaTime;
        if (timer >= segundo && BuffTimer.xtudoAtivado == true)
        {
            player.xtudoAtivo = true;
            BuffTimer.buffDuration -= 1;
            buffDurationText.text = "Buff: " + BuffTimer.buffDuration.ToString();
            timer = 0f;
        }else if(timer >= segundo && BuffTimer.laranjinhaAtivo == true)
        {
            player.laranjinhaAtivo = true;
            BuffTimer.buffDuration -= 1;
            buffDurationText.text = "Buff: " + BuffTimer.buffDuration.ToString();
            timer = 0f;
        }
        if (BuffTimer.buffDuration <= 0)
        {
            player.laranjinhaAtivo = false;
            player.xtudoAtivo = false;
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
            
            buffDurationText.text = "Buff: ";
            BuffTimer.buffDuration = 180;
        }
    }
}
public static class BuffTimer
{
    public static int buffDuration = 180;
    public static bool xtudoAtivado;
    public static bool laranjinhaAtivo;
}
