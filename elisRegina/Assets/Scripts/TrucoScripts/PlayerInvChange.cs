using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvChange : MonoBehaviour
{
    [SerializeField] PlayerCard card1;
    [SerializeField] PlayerCard card2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(card1.cardStrength == card2.cardStrength)
        {
            card1.cardStrength = Random.Range(1, 43);
            card2.cardStrength = Random.Range(1, 43);
            print("troca do inventario");
        }
    }
}
