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
        
        /*if (collision.gameObject.CompareTag("Ground"))
        {

            Destroy(gameObject, 0.5f);

        }
        if (collision.gameObject.CompareTag("Peso"))
        {
            Destroy(gameObject, 0.5f);
        }*/
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
