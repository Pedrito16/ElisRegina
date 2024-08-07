using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 3;
    public int dinheiro;
    public float moveSpeed = 5;
    float horizontal = 1;
    
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
    
    
    public float pesoCooldown = 0.5f;
    [Header("Raio de Intera��o")]
    [SerializeField] private Collider2D playerIntRange;
    public float InteractionRadius = 2;
    public bool Ativador;

    private bool isPesoCooldown = false;
    
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
        //c�digo que fazz o personagem virar de dire��o
        Vector2 scale = playerTransform.localScale;
        scale.x = direction;
        playerTransform.localScale = scale;


        Esquerda.position = transform.position + esquerda;
        Direita.position = transform.position + direita;

        
        //c�digo que movimenta o jogador
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2( horizontal * moveSpeed, body.velocity.y );
        //anima��o do jogador 
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
        //c�digo que faz o peso do jogador
        if (Input.GetButtonDown("Weight") && direction == 1 && isPesoCooldown == false) //1 && Time.time > nextFire
        {
         Instantiate(Peso, Direita.position, transform.rotation);
            StartCoroutine(Cooldown());

        }
        
        if (Input.GetButtonDown("Weight") && direction == -1 && isPesoCooldown == false )
        {
            Instantiate(Peso, Esquerda.position, transform.rotation);
            StartCoroutine(Cooldown());
        }
        if(life <=  0)
        {
            gameOver();
        }

       

    }
    IEnumerator Cooldown()
    {
        isPesoCooldown = true;

        yield return new WaitForSeconds(pesoCooldown);
        
        isPesoCooldown = false;
        yield break;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            life -= collision.gameObject.GetComponent<Tiro>().dano;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<NPC>().eKeybind.SetActive(true);
        }
        if (collision.CompareTag("DoisReal"))
        {
            dinheiro += 2;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("CincoReal"))
        {
            dinheiro += 5;
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("DezReal"))
        {
            dinheiro += 10;
            Destroy(collision.gameObject);
        }
    }
    
    void gameOver()
    {
       life = 0;
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
