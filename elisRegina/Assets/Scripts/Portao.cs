using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{

    public Animator animator;

    private void Update()
    {
       
        if(gameObject.GetComponent<BoxCollider2D>() == null)
        {
            Debug.Log("foi?");
            animator.SetBool("Abrindo", true);
            animator.SetBool("Aberto", true);
        }
        
        
    }
}
