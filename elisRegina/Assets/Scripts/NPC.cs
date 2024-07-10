using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject Ekeybind;
    // Start is called before the first frame update
    void Start()
    {
        Ekeybind.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
