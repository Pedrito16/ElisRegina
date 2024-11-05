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
    [SerializeField] Slider cdFillBar;
    [SerializeField] Sprite[] comidas;
    [SerializeField] Image foodImage;
    private void Start()
    {
        buffDuration = BuffTimer.buffDuration;
         cdFillBar.gameObject.SetActive(false);
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if(BuffTimer.morreu == true)
        {
            ativador = false;
            BuffTimer.buffDuration = 180;
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
        }
        cdFillBar.value = BuffTimer.buffDuration;
        buffDurationText.text = BuffTimer.buffDuration.ToString();
        timer += Time.deltaTime;
        if(BuffTimer.xtudoAtivado == true && ativador == false)
        {
            player.moveSpeed *= 1.25f;
            ativador = true;
        }else if(BuffTimer.laranjinhaAtivo == true && ativador == false)
        {
            player.jumpStrenght *= 1.25f;
            ativador = true;
        }

        if (timer >= segundo && BuffTimer.xtudoAtivado == true )
        {
            
            player.notActiveBuffs = false;
            BuffTimer.buffDuration -= 1;
            timer = 0f;
        }else if(timer >= segundo && BuffTimer.laranjinhaAtivo == true)
        {
            player.laranjinhaAtivo = true;
            player.notActiveBuffs = false;
            BuffTimer.buffDuration -= 1;
            timer = 0f;
        }
        if (BuffTimer.buffDuration <= 0)
        {
            ativador = false;
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
            player.notActiveBuffs = true;
            BuffTimer.buffDuration = 180;
        }
    }
    
}
public static class BuffTimer
{
    public static int buffDuration = 180;
    public static bool xtudoAtivado;
    public static bool laranjinhaAtivo;
    public static bool morreu = false;
}
