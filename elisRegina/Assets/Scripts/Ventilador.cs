using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float velocitySpeed;
    [SerializeField] GameObject ventoBaixoObject, ventoCimaObject;
    public ParticleSystem ventoBaixo, ventoCima;
    public Alavanca alavancaScript;
    [SerializeField] Animator ventiladorAnimator;
    [SerializeField] bool inverter = false; //serve para inverter os sentidos
    void Update()
    {
        ventiladorAnimator.SetBool("Trocar", !alavancaScript.currentState);
        if (alavancaScript.currentState == true && inverter == false)
        {
            ventoCimaObject.SetActive(false);
            ventoBaixoObject.SetActive(true);
            ventoBaixo.Play();
        }
        else if(alavancaScript.currentState == true && inverter == true) 
        {
            ventoCimaObject.SetActive(true);
            ventoBaixoObject.SetActive(false);
            ventoCima.Play();
        }
        if(alavancaScript.currentState == false && inverter == false) 
        {
            ventoCimaObject.SetActive(true);
            ventoBaixoObject.SetActive(false);
            ventoCima.Play();
        }
        else if(alavancaScript.currentState == false && inverter == true) //se o estado atual for verde
        {
            ventoCimaObject.SetActive(false);
            ventoBaixoObject.SetActive(true);
            ventoBaixo.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(alavancaScript.currentState == true && inverter == false)
            { //empurrando pra cima
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed;
                rb.velocity = newYvelocity;
            }
            else if(alavancaScript.currentState == false && inverter == false)
            { //empurrando pra baixo
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed * -1;
                rb.velocity = newYvelocity;
            }
            if(inverter == true && alavancaScript.currentState == true)
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed * -1;
                rb.velocity = newYvelocity;
            }
            else if(inverter == true && alavancaScript.currentState == false)
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed;
                rb.velocity = newYvelocity;
            }
        }
    }
}
