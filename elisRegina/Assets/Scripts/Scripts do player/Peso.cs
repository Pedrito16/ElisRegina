using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
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
        if (collision.gameObject.CompareTag("Ground"))
        {

            Destroy(gameObject, 1f);

        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}