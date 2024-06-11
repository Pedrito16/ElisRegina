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
    void Start()
    {
        //playerTransform.localScale = new Vector2(direction, 1);
        
    }

    void Update()
    {
        Vector2 scale = playerTransform.localScale;
        scale.x = direction;
        playerTransform.localScale = scale;

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



    }   
}
