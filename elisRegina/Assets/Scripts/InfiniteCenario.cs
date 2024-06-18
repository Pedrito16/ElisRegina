using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCenario : MonoBehaviour
{
    public float velociadeDoCenario;

    void Update()
    {
        MovimentarCenario();
    }
    void MovimentarCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velociadeDoCenario, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}

