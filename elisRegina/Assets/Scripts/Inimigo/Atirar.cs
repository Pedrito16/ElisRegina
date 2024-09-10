using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Enemy enemy;
    public GameObject tiro;
    public float tiroSpeed;
    [SerializeField] private float segundosParaAtirar;
    [SerializeField] bool ativador = false;
    float timer;
    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= segundosParaAtirar && ativador == true)
        {
            GameObject temp = Instantiate(tiro, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(tiroSpeed * enemy.direction, 0);
            timer = 0;
        } 
    }
    
    private void OnBecameVisible()
    {
        ativador = true;
    }
    private void OnBecameInvisible()
    {
        ativador = false;
    }
}
