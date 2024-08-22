using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lojinha : MonoBehaviour
{
    public GameObject eKeybind;
    public GameObject lojaUI;
    public bool UISetActive = false;
    [SerializeField] bool isCollidingPlayer = false;
    void Start()
    {
        eKeybind.SetActive(false);
        lojaUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollidingPlayer = true;
            eKeybind.SetActive(true);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            isCollidingPlayer = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eKeybind.SetActive(false);
            lojaUI.SetActive(false);
            isCollidingPlayer = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true)
        {
            lojaUI.SetActive(true);
            UISetActive = true;
            
        }
        
        
    }
    public void XDeactivator()
    {
        Time.timeScale = 1f;
    }
}
