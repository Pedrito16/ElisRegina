using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float velocidadeDoCenario;
    public Transform cameraTransform;
    private float length, startPosition;
    public GameObject cam;
    public float efeitoParallax;
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = (cam.transform.position.x * efeitoParallax);
        transform.position = new Vector3(startPosition + distancia, transform.position.y, transform.position.z);
        float returnBG = (cam.transform.position.x * (1 - efeitoParallax));
        if (returnBG > startPosition + length)
        {
            startPosition = length;
        }
        else if (returnBG < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
