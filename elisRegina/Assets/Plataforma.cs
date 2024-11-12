using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float velocidade = 2f; // Velocidade de movimento
    public float alturaMaxima = 3f; // Altura máxima que a plataforma pode atingir
    public float alturaMinima = -3f; // Altura mínima da plataforma
    private Vector3 posicaoInicial; // Posição inicial da plataforma
    private bool movendoParaCima = true; // Se a plataforma está se movendo para cima

    void Start()
    {
        // Salva a posição inicial da plataforma
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
                movendoParaCima = false; // Muda a direção
            }
        }
        else
        {
            transform.position -= Vector3.up * velocidade * Time.deltaTime;

            if (transform.position.y <= posicaoInicial.y + alturaMinima)
            {
                movendoParaCima = true; // Muda a direção
            }
        }
    }
}
