using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFlip : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    float offset; //a distancia entre a torreta e o player
    public int direction;
    public int life = 10;
    [SerializeField]public bool ativada;
    [SerializeField] Animator animator;
    Coroutine blinkRoutine;
    [SerializeField] Material originalMaterial;
    [SerializeField] Material hitMaterial;
    [SerializeField] GameObject cincoConto;
    [SerializeField] BotaoVerde botaoVerde;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        CalcularOffset();
        animator = GetComponent<Animator>();
        originalMaterial = GetComponent<SpriteRenderer>().material;
        ativada = true;
        botaoVerde = GetComponentInChildren<BotaoVerde>();
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
    void Update()
    {
        animator.SetBool("Ativada", ativada);
        CalcularOffset();
        if(life <= 0)
        {
             Morrer();
             Destroy(gameObject);
        }
        if(offset >= 0 && ativada)
        {
            Vector3 scale = gameObject.transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x) * -1;
            gameObject.transform.localScale = scale;
        }else if(offset < 0 && ativada)
        {
            Vector3 scale = gameObject.transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x);
            gameObject.transform.localScale = scale;
        }
    }
    void Morrer()
    {
        Instantiate(cincoConto, transform.position, transform.rotation);
        Destroy(botaoVerde.wireTransform.gameObject);
    }
    private void OnBecameVisible()
    {
        CalcularOffset();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Peso") && ativada)
        {
            life -= other.GetComponent<Peso>().damage;
            Destroy(other.gameObject);
            piscar();   
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Peso") && ativada)
        {
            life -= other.gameObject.GetComponent<Peso>().damage;
            Destroy(other.gameObject);
            piscar();
        }
    }
    void CalcularOffset()
    {
        if(playerTransform != null)
        {
            offset = playerTransform.position.x - gameObject.transform.position.x;
        }
        direction = (int)offset;
        direction = Mathf.Clamp(direction, -1, 1);
        if(direction == 0)
        {
            direction = 1;
        }
    }
}
