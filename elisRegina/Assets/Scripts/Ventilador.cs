using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float velocityYSpeed;
    public ParticleSystem ventoBaixo, ventoCima;
    void Start()
    {
        ventoBaixo.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 newVelocity = rb.velocity;
            newVelocity.y = velocityYSpeed;
            rb.velocity = newVelocity;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 newVelocity = rb.velocity;
            newVelocity.y = velocityYSpeed;
            rb.velocity = newVelocity;
        }
    }
}
