using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RoundsController : MonoBehaviour
{
    public GameObject[] contadores;
    public Sprite[] vitoriaDerrota;
    public int  rodadaEscolhida; // é a rodada escolhida para o contador de vitória agir individualmente
    public Bundle bundle;
    public Canvas canvas;
    [SerializeField] AudioSource soundtrackBar;
    [SerializeField] GameObject introdução;
    private void Awake()
    {
        if (RodadasSystem.rodadaAtual <= 0)
        {
            introdução.SetActive(true);
        }
        else
        {
            introdução.SetActive(false);
        }
        if (RodadasSystem.soundtrackTime != 0)
        {
            soundtrackBar.time = RodadasSystem.soundtrackTime;
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Truco")
        {
            bundle = FindObjectOfType<Bundle>();
            introdução = GameObject.FindWithTag("HUD");
            soundtrackBar = FindObjectOfType(typeof(AudioSource)) as AudioSource;
        }
        else if(SceneManager.GetActiveScene().name != "Truco" )
        {
            Destroy(transform.root.gameObject);
            RodadasSystem.ganhou = 0;
            RodadasSystem.perdeu = 0;
        }
        if (RodadasSystem.rodadaAtual == 0)
        {
            canvas.sortingOrder = 11;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        RodadasSystem.soundtrackTime = soundtrackBar.time;
        print(RodadasSystem.soundtrackTime.ToString());
        if (bundle.ganhou)
        {
            contadores[RodadasSystem.rodadaAtual - 1].GetComponent<Image>().sprite = vitoriaDerrota[0];
            print(RodadasSystem.soundtrackTime.ToString());
        }
        else if (bundle.perdeu)
        {
            contadores[RodadasSystem.rodadaAtual - 1].GetComponent<Image>().sprite = vitoriaDerrota[1];
            RodadasSystem.soundtrackTime = soundtrackBar.time;
        }
    }
}
public static class RodadasSystem
{
    public static int ganhou, perdeu;
    public static int rodadaAtual = 0;
    public static float soundtrackTime;
}