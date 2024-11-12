using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float velocidade = 2f; // Velocidade de movimento
    public float alturaMaxima = 3f; // Altura m�xima que a plataforma pode atingir
    public float alturaMinima = -3f; // Altura m�nima da plataforma
    private Vector3 posicaoInicial; // Posi��o inicial da plataforma
    private bool movendoParaCima = true; // Se a plataforma est� se movendo para cima

    void Start()
    {
        // Salva a posi��o inicial da plataforma
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Faz o movimento para cima e para baixo
        if (movendoParaCima)
        {
            transform.position += Vector3.up * velocidade * Time.deltaTime;

            if (transform.position.y >= posicaoInicial.y + alturaMaxima)
            {
                movendoParaCima = false; // Muda a dire��o
            }
        }
        else
        {
            transform.position -= Vector3.up * velocidade * Time.deltaTime;

            if (transform.position.y <= posicaoInicial.y + alturaMinima)
            {
                movendoParaCima = true; // Muda a dire��o
            }
        }
    }
}
