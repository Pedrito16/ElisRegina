using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Ventilador : MonoBehaviour
{
    public float velocitySpeed;
    
    [SerializeField] GameObject ventoBaixoObject, ventoCimaObject;
    public ParticleSystem ventoBaixo, ventoCima;
    public Alavanca alavancaScript;
    [SerializeField] Animator ventiladorAnimator;
    [SerializeField] bool inverter = false; //serve para inverter os sentidos
    private void Start()
    {
        if (alavancaScript.currentState)
        {
            ventoBaixo.Play();
        }
        else
        {
            ventoCima.Play();
        }
    }
    void Update()
    {
        if(!inverter) 
        {
            ventiladorAnimator.SetBool("Trocar", !alavancaScript.currentState);
        }
        else
        {
            ventiladorAnimator.SetBool("Trocar", alavancaScript.currentState);
        }
        
        if (alavancaScript.currentState == true && inverter == false)
        {
            if (ventoCima.isPlaying)
            {
                ventoCima.Stop();
            }
            if (!ventoBaixo.isPlaying)
            {
                ventoBaixo.Play();
            }
        }
        else if(alavancaScript.currentState == true && inverter == true) 
        {
            if (ventoBaixo.isPlaying)
            {
                ventoBaixo.Stop();
            }
            if (!ventoCima.isPlaying)
            {
                ventoCima.Play();
            }
        }
        if(alavancaScript.currentState == false && inverter == false)
        {
            if (ventoBaixo.isPlaying)
            {
                ventoBaixo.Stop();
            }
            if (!ventoCima.isPlaying)
            {
                ventoCima.Play();
            }
        }
        else if(alavancaScript.currentState == false && inverter == true) //se o estado atual for verde
        {
            if (ventoCima.isPlaying)
            {
                ventoCima.Stop();
            }
            if (!ventoBaixo.isPlaying)
            {
                ventoBaixo.Play();
            }
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
                newYvelocity.y = velocitySpeed;
                rb.velocity = newYvelocity;
            }
            else if(inverter == true && alavancaScript.currentState == false)
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed * -1;
                rb.velocity = newYvelocity;
            }
        }
    }
}
