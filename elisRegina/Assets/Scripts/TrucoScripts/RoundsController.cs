using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoundsController : MonoBehaviour
{
    public GameObject[] contadores;
    public Sprite[] vitoriaDerrota;
    public int  rodadaEscolhida; // é a rodada escolhida para o contador de vitória agir individualmente
    public Bundle bundle;
    public Canvas canvas;
    private void Awake()
    {
        bundle = FindObjectOfType<Bundle>();
    }
    void Update()
    {
        if(RodadasSystem.rodadaAtual == 0)
        {
            canvas.sortingOrder = 11;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        if (bundle.ganhou)
        {
            if (RodadasSystem.rodadaAtual == 1)
            {
                contadores[0].GetComponent<Image>().sprite = vitoriaDerrota[0];
            }
            else if (RodadasSystem.rodadaAtual == 2)
            {
                contadores[1].GetComponent<Image>().sprite = vitoriaDerrota[0];
            }
            else if (RodadasSystem.rodadaAtual == 3)
            {
                contadores[2].GetComponent<Image>().sprite = vitoriaDerrota[0];
            }
        }
        else if (bundle.perdeu)
        {
            if (RodadasSystem.rodadaAtual == 1)
            {
                contadores[0].GetComponent<Image>().sprite = vitoriaDerrota[1];
            }
            else if (RodadasSystem.rodadaAtual == 2)
            {
                contadores[1].GetComponent<Image>().sprite = vitoriaDerrota[1];
            }
            else if (RodadasSystem.rodadaAtual == 3)
            {
                contadores[2].GetComponent<Image>().sprite = vitoriaDerrota[1];
            }
        }
    }
}
public static class RodadasSystem
{
    public static int ganhou, perdeu;
    public static int rodadaAtual = 0;
}