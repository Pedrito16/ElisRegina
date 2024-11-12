using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public float velocidade = 2f; 
    public float alturaMaxima = 3f; 
    public float alturaMinima = -3f;
    private Vector3 posicaoInicial;
    private bool movendoParaCima = true; 

    void Start()
    {
        
        posicaoInicial = transform.position;
    }

    void Update()
    {
        
        if (movendoParaCima)
        {
            transform.position += Vector3.up * velocidade * Time.deltaTime;

            if (transform.position.y >= posicaoInicial.y + alturaMaxima)
            {
                movendoParaCima = false; 
            }
        }
        else
        {
            transform.position -= Vector3.up * velocidade * Time.deltaTime;

            if (transform.position.y <= posicaoInicial.y + alturaMinima)
            {
                movendoParaCima = true; 
            }
        }
    }
}
