using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuffText : MonoBehaviour
{
    public TextMeshProUGUI buffDurationText;
    [SerializeField] float timer;
    int segundo = 1;
    public bool ativador = false;
    public Player player;
    [SerializeField] Slider cdFillBar;
    [SerializeField] Sprite[] comidas;
    [SerializeField] Image foodImage;
    [SerializeField] Animator garfoFaca;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        foodImage.gameObject.SetActive(false);
        garfoFaca.gameObject.SetActive(false);
        buffDurationText.gameObject.SetActive(false);
        if (BuffTimer.buffDuration > 0 && BuffTimer.xtudoAtivado)
        {
            currentFood();
        }else if(BuffTimer.buffDuration > 0 && BuffTimer.laranjinhaAtivo)
        {
            currentFood();
        }
    }
    void currentFood()
    {
        buffDurationText.gameObject.SetActive(true);
        foodImage.gameObject.SetActive(true);
        foodImage.sprite = BuffTimer.currentSprite;
        BuffTimer.currentSprite = null;
    }
    void Update()
    {
        if(BuffTimer.morreu == true)
        {
            ativador = false;
            BuffTimer.buffDuration = 120;
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
        }
        cdFillBar.value = BuffTimer.buffDuration;
        buffDurationText.text = BuffTimer.buffDuration.ToString();
        timer += Time.deltaTime;
        if (player.notActiveBuffs)
        {
            garfoFaca.gameObject.SetActive(true);
        }
        if(BuffTimer.xtudoAtivado == true && ativador == false)
        {
            player.moveSpeed *= 1.25f;
            foodImage.gameObject.SetActive(true);
            buffDurationText.gameObject.SetActive(true);
            foodImage.sprite = comidas[1];
            BuffTimer.currentSprite = comidas[1];
            ativador = true;
        }else if(BuffTimer.laranjinhaAtivo == true && ativador == false)
        {
            player.jumpStrenght *= 1.25f;
            foodImage.gameObject.SetActive(true);
            buffDurationText.gameObject.SetActive(true);
            foodImage.sprite = comidas[2];
            BuffTimer.currentSprite = comidas[2];
            ativador = true;
        }

        if (timer >= segundo && BuffTimer.xtudoAtivado == true )
        {
            
            player.notActiveBuffs = false;
            player.oneTimeActiveBuff = false;
            BuffTimer.buffDuration -= 1;
            garfoFaca.gameObject.SetActive(false);
            timer = 0f;
        }else if(timer >= segundo && BuffTimer.laranjinhaAtivo == true)
        {
            player.notActiveBuffs = false;
            player.oneTimeActiveBuff = false;
            BuffTimer.buffDuration -= 1;
            garfoFaca.gameObject.SetActive(false);
            timer = 0f;
        }
        if (BuffTimer.buffDuration <= 0)
        {
            ativador = false;
            foodImage.sprite = null;
            garfoFaca.gameObject.SetActive(true);
            buffDurationText.gameObject.SetActive(false);
            foodImage.gameObject.SetActive(false);
            BuffTimer.xtudoAtivado = false;
            BuffTimer.laranjinhaAtivo = false;
            player.notActiveBuffs = true;
            player.oneTimeActiveBuff = true;
            BuffTimer.buffDuration = 120;
        }
    }
    
}
public static class BuffTimer
{
    public static int buffDuration = 120;
    public static Sprite currentSprite;
    public static bool xtudoAtivado;
    public static bool laranjinhaAtivo;
    public static bool morreu = false;
}
