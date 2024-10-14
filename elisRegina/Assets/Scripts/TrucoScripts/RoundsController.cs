using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsController : MonoBehaviour
{
    public GameObject[] contadores;
    public Sprite[] vitoriaDerrota;
    public int RodadaAtual = 1, rodadaEscolhida; // é a rodada escolhida para o contador de vitória agir individualmente
    public Bundle bundle;
    private void Awake()
    {
        bundle = FindObjectOfType<Bundle>();
    }
    void Start()
    {
        PlayerPrefs.GetInt("Rodada", RodadaAtual);
    }
    void Update()
    {
        if (RodadaAtual == 1 && bundle.ganhou)
        {
            contadores[0].GetComponent<Image>().sprite = vitoriaDerrota[0];
        }else if (RodadaAtual == 1 && bundle.perdeu)
        {
            contadores[0].GetComponent<Image>().sprite = vitoriaDerrota[1];
        }
    }
}
public static class RodadasSystem
{
    public static int ganhou, perdeu;
}