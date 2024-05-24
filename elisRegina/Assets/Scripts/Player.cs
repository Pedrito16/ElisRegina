using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int moveSpeed = 5;
    float horizontal;
    public int score;
    public float jumpStrenght = 5;
    public Rigidbody2D body;
    public bool groundCheck;
    public Transform foot;

    public int direction = 1;
    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2( horizontal * moveSpeed, body.velocity.y );

        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);

        if(Input.GetButtonDown("Jump")&&  groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrenght * 100));

        }
        if(horizontal != 0)
        {

            direction = (int)horizontal;
        }
    }   
}
