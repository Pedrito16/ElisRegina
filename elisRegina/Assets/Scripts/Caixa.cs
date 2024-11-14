using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            Destroy(collision.gameObject);
        }
    }
}
