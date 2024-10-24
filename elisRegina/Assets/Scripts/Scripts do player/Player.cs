using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player     : MonoBehaviour
{
    public int life = 3;
    public int dinheiro;
    public float moveSpeed = 5;
    [SerializeField]float horizontal = 1;
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
    [SerializeField] ParticleSystem fumaçaPé;
    [SerializeField] AudioClip coinPickup;
    [SerializeField] public SFX SFXscript;
    private Vector3 esquerda;
    private Vector3 direita;
    float invensibilityTime = 0.75f;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material redMaterial;
    [SerializeField] bool isInvensible;
    [Header("Coyote Time e jump Buffering")]
    float coyoteTime = 0.05f;
    float coyoteTimeCounter;
    [Header("Buffs ativos")]
    public bool xtudoAtivo, laranjinhaAtivo;
    public bool notActiveBuffs = true;
    [SerializeField] bool UnlockedPower;
    Coroutine blinkRoutine;
    void Start()
    {
        //playerTransform.localScale = new Vector2(direction, 1);
        esquerda = Esquerda.position - transform.position;
        inicialMovespeed = moveSpeed;
        inicialJumpStrength = jumpStrenght;
        direita = Direita.position - transform.position;
        dinheiro = PlayerPrefs.GetInt("Dinheiro");
        defaultMaterial = gameObject.GetComponent<SpriteRenderer>().material;
        if(Powers.locationSalva)
        {
           transform.position = Powers.lastSavedLocation;
           Powers.locationSalva = false;
           Powers.lastSavedLocation = new Vector3(0,0,0);
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Tutorial")
        {
            Powers.unlockPower = true;
        }
        //código que fazz o personagem virar de direção
        if (groundCheck)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
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
        footCollider = Physics2D.OverlapCircle(foot.position, 0.13f, filtro);
        groundCheck = footCollider;
        PlayerPrefs.SetInt("Dinheiro", dinheiro);

        if(Input.GetButtonDown("Jump") &&  coyoteTimeCounter > 0)
        {
            body.AddForce(new Vector2(0, jumpStrenght * 75));
            coyoteTimeCounter = 0; 
        }
        if(horizontal != 0)
        {
            direction = (int)horizontal;
        }
        //código que faz o peso do jogador
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
        if (Input.GetButtonDown("Horizontal") && groundCheck)
        {
            fumaçaPé.Play();
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
        if (collision.CompareTag("CleideUnlockPower"))
        {
            UnlockedPower = true;
            Powers.unlockPower = UnlockedPower;
        }
        if (collision.gameObject.CompareTag("Peso"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Tiro"))
        {
            if (!isInvensible)
            {
                explosão.Play();
                life -= collision.gameObject.GetComponent<Tiro>().dano;
                Destroy(collision.gameObject);
                Pisca();
                StartCoroutine(invensibility());
            }
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
        if (collision.CompareTag("Sebastian"))
        {
            Powers.lastSavedLocation = gameObject.transform.position;
            Powers.locationSalva = true;
        }
    }
    public void Pisca()
    {
        if(blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
        }
        blinkRoutine = StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        SpriteRenderer player = GetComponent<SpriteRenderer>();
        player.material = redMaterial;
        yield return new WaitForSeconds(0.35f);
        player.material = defaultMaterial;
        blinkRoutine = null;
    }
    IEnumerator invensibility()
    {
        isInvensible = true;
        yield return new WaitForSeconds(invensibilityTime);
        isInvensible = false;
    }
    void gameOver()
    {
       life = 0;
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
    public static Vector3 lastSavedLocation;
    public static Vector3 previousSavedLocation;
    public static bool locationSalva;
}