using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFlip : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float offset; //a distancia entre a torreta e o player
    public int direction;
    public int life = 10;
    [SerializeField] TurretShoot turretShoot;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        turretShoot = GetComponent<TurretShoot>();
        CalcularOffset();
    }
    void Update()
    {
        if(gameObject.activeSelf)
        {
            CalcularOffset();
        }
        if(offset >= 0)
        {
            Vector3 scale = gameObject.transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x) * -1;
            gameObject.transform.localScale = scale;
        }else if(offset < 0)
        {
            Vector3 scale = gameObject.transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x);
            gameObject.transform.localScale = scale;
        }
    }
    private void OnBecameVisible()
    {
        CalcularOffset();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Peso"))
        {
            life -= other.GetComponent<Peso>().damage;
        }
        if (other.CompareTag("Player"))
        {
            if (turretShoot.inCooldown)
            {
                other.GetComponent<Player>().life -= 1;
            }
        }
    }
    void CalcularOffset()
    {
        offset = playerTransform.position.x - gameObject.transform.position.x;
        direction = (int)offset;
        direction = Mathf.Clamp(direction, -1, 1);
        if(direction == 0)
        {
            direction = 1;
        }
    }
}
