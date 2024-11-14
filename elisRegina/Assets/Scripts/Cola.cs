using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola : MonoBehaviour
{
    [SerializeField] float slowValue, jumpSlowValue;
    //pega o valor inicial da velocidade e poder de pulo(antes de aplicar o slow)
    float initialMoveSpeedValue, initialJumpStrengthValue;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Colidindo");
            initialMoveSpeedValue = collision.gameObject.GetComponent<Player>().moveSpeed;
            initialJumpStrengthValue = collision.gameObject.GetComponent<Player>().jumpStrenght;
            collision.gameObject.GetComponent<Player>().moveSpeed -= slowValue;
            collision.gameObject.GetComponent<Player>().jumpStrenght -= jumpSlowValue;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().moveSpeed = initialMoveSpeedValue;
            collision.gameObject.GetComponent<Player>().jumpStrenght = initialJumpStrengthValue;
        }
    }
}
