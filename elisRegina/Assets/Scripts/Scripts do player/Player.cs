using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    float horizontal = 1;
    public int score;
    public float jumpStrenght = 5;
    public Rigidbody2D body;
    public bool groundCheck;
    public Transform foot;
    public GameObject Peso;
    public int direction = 1;
    public Transform Direita, Esquerda;
    public float fireRate = 0.5f;
    public float nextFire = 0.5f;
    public Animator animator;
    public Transform playerTransform;
    public int life = 3;
    
    private Vector3 esquerda;
    private Vector3 direita;
    public GameObject GameOver;
    void Start()
    {
        //playerTransform.localScale = new Vector2(direction, 1);
        esquerda = Esquerda.position - transform.position;
        direita = Direita.position - transform.position;
    }

    void Update()
    {
        Vector2 scale = playerTransform.localScale;
        scale.x = direction;
        playerTransform.localScale = scale;


        Esquerda.position = transform.position + esquerda;
        Direita.position = transform.position + direita; 


        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2( horizontal * moveSpeed, body.velocity.y );

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        

        if(Input.GetButtonDown("Jump")&&  groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrenght * 75));

        }
        if(horizontal != 0)
        {

            direction = (int)horizontal;
        }
        
        if (Input.GetButtonDown("Weight") && direction == 1) //1 && Time.time > nextFire
        {
         Instantiate(Peso, Direita.position, transform.rotation);

        }
        else if (Input.GetButtonDown("Weight") && direction == -1)
        {
            Instantiate(Peso, Esquerda.position, transform.rotation);

        }
        if(life <=  0)
        {

            gameOver();

            
;

        }

       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            Debug.Log("Colidiu");
            life -= collision.gameObject.GetComponent<Tiro>().dano;
            Destroy(collision.gameObject);
            
            

        }
    }
    
    void gameOver()
    {
       GameOver.SetActive(true);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Espinho"))
        {
            gameOver();
            

        }
        if (collision.gameObject.CompareTag("Peso"))
        {
            Destroy(collision.gameObject);

        }
    }
}
