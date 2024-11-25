using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosition;
    public GameObject cam;
    public float efeitoParallax;
    void Start()
    {
        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float returnBG = (cam.transform.position.x * (1 - efeitoParallax));
        float distancia = (cam.transform.position.x * efeitoParallax);
        transform.position = new Vector3(startPosition + distancia, transform.position.y, transform.position.z);
        //peguei essa parte do youtube porque nao sei fazer parallax
        if(returnBG > startPosition + length)
        {
            startPosition = length;
        }else if(returnBG < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
