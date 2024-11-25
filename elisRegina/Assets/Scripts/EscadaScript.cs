using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaScript : MonoBehaviour
{
    [SerializeField] float velocitySpeed;
    [SerializeField] GameObject interactionW;
    void Start()
    {
      interactionW.SetActive(false);
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionW.SetActive(true);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                Vector2 newVelocitySpeed = rb.velocity;
                newVelocitySpeed.y = velocitySpeed;
                rb.velocity = newVelocitySpeed;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionW.SetActive(false);
        }
    }
}
