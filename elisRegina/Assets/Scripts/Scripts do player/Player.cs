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
    [SerializeField] ParticleSystem explos„o;
    [SerializeField] AudioClip coinPickup;
    [SerializeField] public SFX SFXscript;
    private Vector3 esquerda;
    private Vector3 direita;
    public GameObject GameOver;
    [Header("Buffs ativos")]
    public bool xtudoAtivo, laranjinhaAtivo;
    public bool notActiveBuffs = true;
    [SerializeField] bool soPr·Testa;
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
        //cÛdigo que fazz o personagem virar de direÁ„o
        if(gameObject == null)
        {
            explos„o.Play();
        }
        Vector2 scale = playerTransform.localScale;
        scale.x = direction;
        playerTransform.localScale = scale;
        Esquerda.position = transform.position + esquerda;
        Direita.position = transform.position + direita;
        //cÛdigo que movimenta o jogador
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
        //animaÁ„o do jogador 
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        footCollider = Physics2D.OverlapCircle(foot.position, 0.13f, filtro);
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
        //cÛdigo que faz o peso do jogador
        if (Input.GetButtonDown("Weight") && direction == 1 && isPesoCooldown == false && Powers.unlockPower == true) //1 && Time.time > nextFire
        {
            Instantiate(Peso, Direita.position, transform.rotation);
            StartCoroutine(Cooldown());
        }
        
        if (Input.GetButtonDown("Weight") && direction == -1 && isPesoCooldown == false && Powers.unlockPower == true)
        {
            Instantiate(Peso, Esquerda.position, transform.rotation);
            StartCoroutine(Cooldown());
        }
        if(life <=  0)
        {
            explos„o.Play();
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
        Powers.unlockPower = soPr·Testa;
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
        if (collision.CompareTag("CleideUnlockPower"))
        {
            Powers.unlockPower = true;
        }
        if (collision.gameObject.CompareTag("Peso"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Tiro"))
        {
            explos„o.Play();
            life -= collision.gameObject.GetComponent<Tiro>().dano;
            Destroy(collision.gameObject);
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
public static class Powers
{
    public static bool unlockPower = false;
}