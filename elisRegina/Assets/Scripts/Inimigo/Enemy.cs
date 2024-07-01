using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life = 4;
    public float speed;
    int direction = -1;
    public int damage = 2;
    public Rigidbody2D body;
    public GameObject tiro;
    public float tiroSpeed;
    public Animator animator;
    public Transform enemyTransform;

   
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //gameObject.SetActive(false);
        InvokeRepeating("UmSegundo", 1.5f, 1.5f);
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
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peso"))
        {

            life -= collision.gameObject.GetComponent<Peso>().damage;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            direction *= -1;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Mudador"))
        {

            direction *= -1;

        }

    }
    void UmSegundo()
    {

        Debug.Log("funcionou!");
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
