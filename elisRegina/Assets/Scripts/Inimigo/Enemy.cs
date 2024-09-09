using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public int life = 4;
    public float speed;
    int direction = -1;
    public int damage = 1;
    public Rigidbody2D body;
    public GameObject tiro;
    public float tiroSpeed;
    public Animator animator;
    public Transform enemyTransform;
    [SerializeField] ParticleSystem explosão;
    
    [Header("Loot Dropado")]
    [SerializeField] private int numeroAleatorio;
    public GameObject doisReais;
    public GameObject cincoReais;
    public GameObject dezReais;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //gameObject.SetActive(false);
        InvokeRepeating("UmSegundo", 2f, 2f);
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
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Tijolo"))
        {
            direction *= -1;
        }
       

    }
    private void Derrotado()
    {
        
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
            explosão.Play();
            life -= collision.gameObject.GetComponent<Peso>().damage;
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
