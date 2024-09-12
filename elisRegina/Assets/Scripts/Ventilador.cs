using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float velocityYSpeed;
    
    [SerializeField] GameObject ventoBaixoObject, ventoCimaObject;
    public ParticleSystem ventoBaixo, ventoCima;
    public Alavanca alavancaScript;
    [SerializeField] Animator ventiladorAnimator;
    private void Awake()
    {
        alavancaScript = FindObjectOfType<Alavanca>();
       
    }
    void Update()
    {
        
        if(alavancaScript.currentState == false) //se o estado atual for vermelho
        {
            ventoCima.Play();
            ventoCimaObject.SetActive(true);
            ventoBaixoObject.SetActive(false);
            ventiladorAnimator.SetBool("Trocar", true);
        }else if(alavancaScript.currentState == true) //se o estado atual for verde
        {
            ventoCimaObject.SetActive(false);
            ventoBaixoObject.SetActive(true);
            ventoBaixo.Play();
            ventiladorAnimator.SetBool("Trocar", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (alavancaScript.currentState == true) 
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocityYSpeed * -1;
                rb.velocity = newYvelocity;
            }
            else if(alavancaScript.currentState == false)
            {
                Vector2 newVelocity = rb.velocity;
                newVelocity.y = velocityYSpeed;
                rb.velocity = newVelocity;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (alavancaScript.currentState == true)
            {
                Vector2 newYvelocity = rb.velocity;
                newYvelocity.y = velocityYSpeed * -1;
                rb.velocity = newYvelocity;
            }
            else if (alavancaScript.currentState == false)
            {
                Vector2 newVelocity = rb.velocity;
                newVelocity.y = velocityYSpeed;
                rb.velocity = newVelocity;
            }
        }
    }
}
