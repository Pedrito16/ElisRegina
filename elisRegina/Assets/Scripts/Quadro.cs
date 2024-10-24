using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour
{
    [SerializeField] GameObject InteractionE;
    [SerializeField] GameObject quadroCanva;
    [SerializeField] bool colliding;
    [SerializeField] bool aberto = false;
    [SerializeField] Player player;
     void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding)
        {
            InteractionE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E) && !aberto) 
            { 
                quadroCanva.SetActive(true);
                aberto = true;
                player.isTalking = true;
            }else if(Input.GetKeyDown(KeyCode.E) && aberto)
            {
                quadroCanva.SetActive(false);
                player.isTalking = false;
                aberto = false;
            }
        }
        else
        {
            InteractionE.SetActive(false);
            quadroCanva.SetActive(false);
        }
    }
    public void XBTN()
    {
        quadroCanva.SetActive(false);
        player.isTalking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colliding = false;
        }
    }
}
