using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject eKeybind;
    string[] dialogo;
    // Start is called before the first frame update
    void Start()
    {
        eKeybind.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interaction"))
        {
            Debug.Log("interagindo");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eKeybind.SetActive(false);
        }
    }

}
