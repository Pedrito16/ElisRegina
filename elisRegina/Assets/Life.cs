using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Life : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField]public Animator[] pillsAnimators;
    [SerializeField] bool lostLife;
    bool canLoseLife;
    public bool recoverLife;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        canLoseLife = true;
    }
    void Update()
    {
        if (player.isInvensible && canLoseLife)
        {
            StartCoroutine(loseLife());
        }
        if(recoverLife)
        {
            print("StartCoroutine");
            RecoverLife();
        }
    }
    IEnumerator loseLife()
    {
        canLoseLife = false;
        pillsAnimators[player.life].SetTrigger("Perder");
        yield return new WaitForSeconds(0.5f);
        pillsAnimators[player.life].gameObject.SetActive(false);
        lostLife = true;
        canLoseLife = true;
    }
    void RecoverLife()
    {
        recoverLife = false;
        if (player.life == 3)
        {
            pillsAnimators[2].gameObject.SetActive(true);
            pillsAnimators[2].SetTrigger("Recover");
        }
        else if (player.life == 2)
        {
            pillsAnimators[1].gameObject.SetActive(true);
            pillsAnimators[1].SetTrigger("Recover");
        }
    }
}
