using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassadorCutscene : MonoBehaviour
{
    [SerializeField] GameObject interactionE;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionE.SetActive(true);
        }
    }
}
