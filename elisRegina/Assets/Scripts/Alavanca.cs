using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public GameObject interactionE;
    [SerializeField] bool IsCollidingPlayer;
    [SerializeField] Animator leverAnimator;
    private void Awake()
    {
        interactionE.SetActive(false);
    }
    void Update()
    {
        if(IsCollidingPlayer == true && Input.GetKeyDown(KeyCode.E))
        { 
         
        }
        interactionE.SetActive(IsCollidingPlayer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsCollidingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsCollidingPlayer = false;
        }
    }
}
