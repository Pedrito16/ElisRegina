using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float fricçãoGelo = 0.1f; 
    private Rigidbody2D rb;
    private bool onIce = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float moveInput = Input.GetAxis("Horizontal");

        
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

       
        if (onIce)
        {
            rb.velocity = new Vector2(rb.velocity.x * (1 - fricçãoGelo), rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
   
        if (other.CompareTag("Ice"))
        {
            onIce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Ice"))
        {
            onIce = false;
        }
    }
}
