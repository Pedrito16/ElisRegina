using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCenario : MonoBehaviour
{
    public float velociadeDoCenario;
    public float posicaoZ;
    public Transform cameraTransform;

    void Update()
    {
        MovimentarCenario();
        /*Vector3 newposition = transform.position;
        newposition.z = posicaoZ;
        transform.position = newposition;*/
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, transform.position.z);
    }
    void MovimentarCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velociadeDoCenario, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}

