using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butao : MonoBehaviour
{
   public Animator animator;
    public GameObject portao;
    public bool ativador = false;
    
    private void Update()
    {
        if(ativador == true)
        {
            Destroy(portao.GetComponent<BoxCollider2D>());
            JaPassou.passou = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Peso") || collision.gameObject.CompareTag("Caixa"))
        {
            animator.SetBool("Colisao", true);
            animator.SetBool("finish", true);
            ativador = true;
        }
    }
}
public static class JaPassou
{
    public static bool passou;
}