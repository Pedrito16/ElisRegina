using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdownTime = 5f; 
    private float countdown;
    public GameObject explosionPrefab; 

    void Start()
    {
        countdown = countdownTime; 
    }

    void Update()
    {
        countdown -= Time.deltaTime; 


    }

    void Explode()
    {
        
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (countdown <= 0)
            {
                Explode();
            }

        }
        

        
    }
}
