using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] GameObject skipBTN;
    [SerializeField] string cenaParaSerCarregada;
    [SerializeField] Animator animatorBTN;
    float timer;
    [SerializeField] bool ativador;
    void Start()
    {
        skipBTN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            skipBTN.SetActive(true);
            animatorBTN.SetTrigger("Fade");
            ativador = true;
        }
        if(ativador)
        {
            timer += Time.deltaTime;
        }
        if(timer > 2f && ativador)
        {
            skipBTN.SetActive(false);
            timer = 0;
            ativador = false;
        }
    }
    public void Skip()
    {
        SceneManager.LoadScene(cenaParaSerCarregada);
    }
}
