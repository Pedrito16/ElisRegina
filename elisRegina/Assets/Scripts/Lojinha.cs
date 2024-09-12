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
    public Animator panel;
    public bool panelAtivo;
    void Start()
    {
        eKeybind.SetActive(false);
        audioSource.clip = DomingoANoite;
        lojaUI.SetActive(false);
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollidingPlayer = true;
            audiocontroller.audiosource.volume = 0;
         
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
        if (Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && panelAtivo == false)
        {
            lojaUI.SetActive(true);
            StartCoroutine(Open());

        }else if(Input.GetKeyDown(KeyCode.E) && isCollidingPlayer == true && panelAtivo == true)
        {
            StartCoroutine(Close());
            panelAtivo = false;
        }
    }
    IEnumerator Open()
    {
        panel.SetTrigger("AtivarUI");
        yield return new WaitForSeconds(1);
        panelAtivo = true;
    }
    IEnumerator Close()
    {
        panel.SetTrigger("DesativarUI");
        yield return new WaitForSeconds(1);
        lojaUI.SetActive(false);
    }
    public void XDeactivator()
    {
        StartCoroutine(Close());
    }
}
