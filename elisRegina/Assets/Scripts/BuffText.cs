using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffText : MonoBehaviour
{
    public Text buffDurationText;
    public int buffDuration = 180;
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
            buffDuration -= 1;
            buffDurationText.text = "Buff: " + buffDuration.ToString();
            
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
