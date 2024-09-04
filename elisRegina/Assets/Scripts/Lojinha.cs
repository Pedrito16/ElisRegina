using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lojinha : MonoBehaviour
{
    public GameObject eKeybind;
    public GameObject lojaUI;
    public bool UISetActive = false;
    [SerializeField] bool isCollidingPlayer = false;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip DomingoANoite;
    public AudioController audiocontroller;
    
    void Start()
    {
        eKeybind.SetActive(false);
        audioSource.clip = DomingoANoite;
        lojaUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollidingPlayer = true;
            audiocontroller.audiosource.volume = 0;
            audioSource.Play();
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
            audioSource.Stop();
            audiocontroller.audiosource.volume = 1;
            lojaUI.SetActive(false);
            isCollidingPlayer = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true)
        {
            lojaUI.SetActive(true);
            print("Apertou E");
        }
        
        
    }
    public void XDeactivator()
    {
        Time.timeScale = 1f;
    }
}
