using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player     : MonoBehaviour
{
    public int life = 3;
    public int dinheiro;
    public float moveSpeed = 5;
    float horizontal = 1;
    public float inicialMovespeed;
    public float jumpStrenght = 5;
    float inicialJumpStrength;
    public Rigidbody2D body;
    public bool groundCheck;
    public Transform foot;
    public Collider2D footCollider;
    public GameObject Peso;
    public int direction = 1;
    public Transform Direita, Esquerda;
    public float fireRate = 0.5f;
    public float nextFire = 0.5f;
    public Animator animator;
    public Transform playerTransform;
    public LayerMask filtro;
    public bool isBuffActive = false;
    public bool isTalking = false;
    public float pesoCooldown = 0.5f;
    private bool isPesoCooldown = false;
    [SerializeField] ParticleSystem explosão;
    [SerializeField] AudioClip coinPickup;
    [SerializeField] public SFX SFXscript;
    private Vector3 esquerda;
    private Vector3 direita;
    public GameObject GameOver;
    [Header("Buffs ativos")]
    public bool xtudoAtivo, laranjinhaAtivo;
    public bool notActiveBuffs = true;
    void Start()
    {
        //playerTransform.localScale = new Vector2(direction, 1);
        esquerda = Esquerda.position - transform.position;
        inicialMovespeed = moveSpeed;
        inicialJumpStrength = jumpStrenght;
        direita = Direita.position - transform.position;
        dinheiro = PlayerPrefs.GetInt("Dinheiro");
        
    }

    void Update()
    {
        //código que fazz o personagem virar de direção
        if(gameObject == null)
        {
            explosão.Play();
        }
        Vector2 scale = playerTransform.localScale;
        scale.x = direction;
        playerTransform.localScale = scale;
        Esquerda.position = transform.position + esquerda;
        Direita.position = transform.position + direita;
        //código que movimenta o jogador
        if(isTalking == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }
        else if(isTalking == true) 
        {
            body.velocity = new Vector2(0, 0);
        }
        //animação do jogador 
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        footCollider = Physics2D.OverlapCircle(foot.position, 0.05f, filtro);
        groundCheck = footCollider;
        PlayerPrefs.SetInt("Dinheiro", dinheiro);
        if(Input.GetButtonDown("Jump")&&  groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrenght * 75));
        }
        if(horizontal != 0)
        {
            direction = (int)horizontal;
        }
        //código que faz o peso do jogador
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
            explosão.Play();
            gameOver();
        }
        if(notActiveBuffs == true) 
        {
            moveSpeed = inicialMovespeed;
            jumpStrenght = inicialJumpStrength;
        }
        
        if(Dourado.playerDourado == true)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
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
            explosão.Play();
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
            collision.GetComponent<DinheiroScript>().dinheiroParticula.Play();
            SFXscript.SFXsource.clip = SFXscript.coinPickup;
            SFXscript.SFXsource.Play();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("CincoReal"))
        {
            dinheiro += 5;
            collision.GetComponent<DinheiroScript>().dinheiroParticula.Play();
            SFXscript.SFXsource.clip = SFXscript.coinPickup;
            SFXscript.SFXsource.Play();
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("DezReal"))
        {
            dinheiro += 10;
            collision.GetComponent<DinheiroScript>().dinheiroParticula.Play();
            SFXscript.SFXsource.clip = SFXscript.coinPickup;
            SFXscript.SFXsource.Play();
            Destroy(collision.gameObject);
        }
    }
    void gameOver()
    {
       life = 0;
       GameOver.SetActive(true);
        Destroy(gameObject);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Enemy>().damage;
        }
    }
}
