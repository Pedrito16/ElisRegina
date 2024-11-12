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
    [SerializeField] bool invertHorizontal; //Serve para inverter de deitado, para em pé
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
        
        if (alavancaScript.currentState == true && inverter == false || alavancaScript.currentState == true && invertHorizontal && !inverter)
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
        else if(alavancaScript.currentState == true && inverter == true || alavancaScript.currentState == true && invertHorizontal && inverter) 
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
            if(alavancaScript.currentState == true && inverter == false && !invertHorizontal)
            { //empurrando pra cima
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed;
                rb.velocity = newYvelocity;
            }
            else if(alavancaScript.currentState == false && inverter == false && !invertHorizontal)
            { //empurrando pra baixo
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed * -1;
                rb.velocity = newYvelocity;
            }
            if(alavancaScript.currentState == false && invertHorizontal && !inverter)
            {
                Vector2 newXvelocity = rb.velocity;
                newXvelocity.x = velocitySpeed * -1;
                rb.velocity = newXvelocity;
            }else if(alavancaScript.currentState == true && invertHorizontal && !inverter)
            {
                Vector2 newXvelocity = rb.velocity;
                newXvelocity.x = velocitySpeed;
                rb.velocity = newXvelocity;
            }
            if(alavancaScript.currentState == false && invertHorizontal && inverter)
            {
                Vector2 newXvelocity = rb.velocity;
                newXvelocity.x = velocitySpeed;
                rb.velocity = newXvelocity;
            }else if(alavancaScript.currentState == true && invertHorizontal && inverter)
            {
                Vector2 newXvelocity = rb.velocity;
                newXvelocity.x = velocitySpeed * -1;
                rb.velocity = newXvelocity;
            }
            if(inverter == true && alavancaScript.currentState == true && !invertHorizontal)
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed * -1;
                rb.velocity = newYvelocity;
            }
            else if(inverter == true && alavancaScript.currentState == false && !invertHorizontal)
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocitySpeed;
                rb.velocity = newYvelocity;
            }
        }
    }
}
