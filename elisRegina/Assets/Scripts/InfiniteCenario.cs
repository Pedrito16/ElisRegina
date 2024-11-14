using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCenario : MonoBehaviour
{
    public float velocidadeDoCenario;
    public float valorY;
    public Transform cameraTransform;
    float originalZPos;
    private void Awake()
    {
        originalZPos = transform.position.z;
    }
    void Update()
    {
        MovimentarCenario();
        /*Vector3 newposition = transform.position;
        newposition.z = posicaoZ;
        transform.position = newposition;*/
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + valorY, originalZPos);
        transform.SetParent(cameraTransform, false);
    }
    void MovimentarCenario()
    {
        //Vector2 deslocamento = new Vector2(Time.time * velocidadeDoCenario, 0);
       //GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}

