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
      if(!inCooldown && ativador)
      {
            animator.SetBool("Regen", false);
            animator.SetBool("Red", false);
            animator.SetBool("TurnRed", false);
            StartCoroutine(Red());
            ativador = false;
      }
      if(timer >= Mathf.Max(fireRate, 0.25f) && gameObject.activeSelf && !inCooldown)
      {
            randomSpawn = Random.Range(-0.25f, 0.25f);
            GameObject temp = Instantiate(tiro, new Vector2(balaTransform.position.x, balaTransform.position.y + randomSpawn), balaTransform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(tiroSpeed * changeDirection.direction, 0);
            timer = 0;
      }
      if(Mathf.Max(fireRate, 0.25f) == 0.25f)
      {
            animator.SetBool("Normal", true);
      }
    }
    IEnumerator Red()
    {
        yield return new WaitForSeconds(6f);
        inCooldown = true;
        animator.SetBool("TurnRed", true);
        animator.SetBool("Red", true);
        animator.SetBool("Normal", false);
        Invoke("Regen", cooldownTime);
    }
    void Regen()
    {
        print("Invokado");
        animator.SetBool("Regen", true);
        fireRate = fireRateMax;
        ativador = true;
        timer = 3;
        inCooldown = false;
    }
}
