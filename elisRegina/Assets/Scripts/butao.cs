using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butao : MonoBehaviour
{
   public Animator animator;
    public GameObject portao;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Foot"))
        {

            Debug.Log("foi");
            animator.SetBool("Colisao", true);

        }
    }
    
}
