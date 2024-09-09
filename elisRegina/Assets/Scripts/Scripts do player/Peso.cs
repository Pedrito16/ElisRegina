using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Peso : MonoBehaviour
{
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tijolo"))
        {
            Destroy(collision.gameObject);
        }
        
        if (!collision.gameObject.CompareTag("Tijolo") /*&& !collision.gameObject.CompareTag("Enemy")*/)
        {
            Destroy(gameObject, 0.75f);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            Destroy(gameObject, 0.75f);
        }
        if (collision.gameObject.CompareTag("Tijolo"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            Destroy(collision.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
