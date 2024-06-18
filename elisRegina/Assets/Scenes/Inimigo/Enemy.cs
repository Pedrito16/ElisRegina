using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
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
        InvokeRepeating("UmSegundo", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed * direction, body.velocity.y);
        Vector2 scale = enemyTransform.localScale;
        scale.x = direction;
        enemyTransform.localScale = scale;
        animator.SetFloat("Speed", speed);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {


            
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
}
