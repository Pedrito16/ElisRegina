using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public int life = 4;
    public float speed;
    public int direction = -1;
    public int damage = 1;
    public Rigidbody2D body;
    public GameObject tiro;
    public GameObject fumaçaParticula;
    public float tiroSpeed;
    public Animator animator;
    public Transform enemyTransform;
    [Header("OnHit")]
    [SerializeField] ParticleSystem explosão;
    [SerializeField] GameObject particulaGota;
    [SerializeField] Material hitMaterial, originalMaterial;
    Coroutine blinkRoutine;
    [Header("Loot Dropado")]
    [SerializeField] private int numeroAleatorio;
    public GameObject doisReais;
    public GameObject cincoReais;
    public GameObject dezReais;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        originalMaterial = GetComponent<SpriteRenderer>().material;
        numeroAleatorio = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed * direction, body.velocity.y);
        Vector2 scale = enemyTransform.localScale;
        scale.x = direction;
        enemyTransform.localScale = scale;
        animator.SetFloat("Speed", speed);
        if(life <= 0) 
        {
            Destroy(gameObject);
            Derrotado();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peso"))
        {
            explosão.Play();
            life -= collision.gameObject.GetComponent<Peso>().damage;
            piscar();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Tijolo"))
        {
            direction *= -1;
        }
       

    }
    void piscar()
    {
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
        }
        blinkRoutine = StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().material = hitMaterial;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material = originalMaterial;
        blinkRoutine = null;
    }
    private void Derrotado()
    {
       GameObject fumacinha = Instantiate(fumaçaParticula, transform.position, transform.rotation);
        Destroy(fumacinha, 0.75f);
        GameObject fumaçaParafuso = Instantiate(particulaGota, transform.position, transform.rotation);
        Destroy(fumaçaParafuso, 0.5f) ;
       if(numeroAleatorio <= 5)
        {
            Instantiate(doisReais, transform.position, transform.rotation);
        }
       if(5 < numeroAleatorio && numeroAleatorio <= 8)
        {
            Instantiate(cincoReais, transform.position, transform.rotation);
        }
       if(numeroAleatorio > 8)
       {
            Instantiate(dezReais, transform.position, transform.rotation);
       }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Mudador"))
        {
            direction *= -1;
        }
        if (collision.gameObject.CompareTag("Peso"))
        {
            if (!explosão.isPlaying)
            {
                explosão.Play();
            }
            life -= collision.gameObject.GetComponent<Peso>().damage;
            piscar();
            Destroy(collision.gameObject);
        }
    }
    void UmSegundo()
    {

       
        GameObject temp = Instantiate(tiro, transform.position, transform.rotation);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(tiroSpeed * direction, 0);

    }
    private void OnBecameVisible()
    {
        /*Debug.Log("visivel");
        gameObject.SetActive(true);
        InvokeRepeating("UmSegundo", 1.5f, 1.5f);*/
    }
    private void OnBecameInvisible()
    {
        //CancelInvoke();
        //gameObject.SetActive(false);

    }
}
