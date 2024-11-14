using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] TurretFlip changeDirection;
    public GameObject tiro;
    public float tiroSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRateMax;
    [SerializeField] 
    float timer;
    float randomSpawn;
    [SerializeField] float cooldownTime;
    [SerializeField] Transform balaTransform;
    [SerializeField] Animator animator;
    [SerializeField] bool inCooldown;
    [SerializeField] float shootingTime;
    bool ativador;
    private void Awake()
    {
        fireRateMax = fireRate;
    }
    void Start()
    {
        changeDirection = GetComponent<TurretFlip>();
        animator = GetComponent<Animator>();
        timer = 3;
        ativador = true;
    }

    // Update is called once per frame
    void Update()
    {
      fireRate -= Time.deltaTime;
      timer += Time.deltaTime;
      shootingTime += Time.deltaTime;
      if(timer >= Mathf.Max(fireRate, 0.25f) && gameObject.activeSelf && !inCooldown)
      {
            randomSpawn = Random.Range(-0.25f, 0.25f);
            GameObject temp = Instantiate(tiro, new Vector2(balaTransform.position.x, balaTransform.position.y + randomSpawn), balaTransform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(tiroSpeed * changeDirection.direction, 0);
            timer = 0;
      }
      animator.SetFloat("Normal", fireRate);
      if(shootingTime >= 7f && !inCooldown && ativador)
      {
            animator.SetBool("Regen", false);
            shootingTime = 0f;
            fireRate = fireRateMax;
            animator.SetBool("TurnRed", true);
            StartCoroutine(Red());
            ativador = false;
      }
    }
    private void OnBecameVisible()
    {
        
    }
    IEnumerator Red()
    {
        inCooldown = true;
        fireRate = fireRateMax;
        yield return new WaitForSeconds(6f);
        fireRate = fireRateMax;
        animator.SetBool("TurnRed", false);
        animator.SetBool("Regen", true);
        inCooldown = false;
        shootingTime = 0f;
        ativador = true;
    }
}
