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
    [SerializeField]public bool inCooldown;
    [SerializeField] float shootingTime;
    bool ativador;
    [SerializeField] bool Visivel;
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
      if(Visivel && changeDirection.ativada)
      {
            fireRate -= Time.deltaTime;
            timer += Time.deltaTime;
            shootingTime += Time.deltaTime;
      }
      if(timer >= Mathf.Max(fireRate, 0.25f) && gameObject.activeSelf && !inCooldown && changeDirection.ativada)
      {
            if (Visivel)
            {
                randomSpawn = Random.Range(-0.25f, 0.25f);
                GameObject temp = Instantiate(tiro, new Vector2(balaTransform.position.x, balaTransform.position.y + randomSpawn), balaTransform.rotation);
                temp.GetComponent<Rigidbody2D>().velocity = new Vector2(tiroSpeed * changeDirection.direction, 0);
            }
            timer = 0;
      }
      animator.SetFloat("Normal", fireRate);
      if(shootingTime >= 7f && !inCooldown && ativador && Visivel && changeDirection.ativada)
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
        Visivel = true;
    }
    private void OnBecameInvisible()
    {
        Visivel = false;
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
