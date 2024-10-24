using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LuzColission : MonoBehaviour
{
    [SerializeField] GameObject luz, strongerLuz, interactionW;
    [SerializeField] Animator trianguloAnim;
    void Start()
    {
        interactionW.SetActive(false);
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trianguloAnim.SetBool("Colidindo", true);
            strongerLuz.SetActive(true);
            luz.SetActive(false);
            interactionW.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            strongerLuz.SetActive(false);
            trianguloAnim.SetBool("Colidindo", false);
            luz.SetActive(true);
            interactionW.SetActive(false);
        }
    }
}
