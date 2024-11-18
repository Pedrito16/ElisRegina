using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoVerde : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TurretFlip turretFlip;
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 wirePos;
    [SerializeField] Vector3 wireRotation;
    [SerializeField] Transform wireTransform;
    void Start()
    {
        animator = GetComponent<Animator>();
        turretFlip = GetComponentInParent<TurretFlip>();
        position = transform.position;
        wirePos = wireTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(wireTransform != null)
        {
            wireTransform.position = wirePos;
        }
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Peso"))
        {
            animator.SetBool("Pressed", true);
            turretFlip.ativada = false;
        }
    }
}
