using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public SpritesTruco sprites;
    public GameObject cards;
    private void Awake()
    {
        sprites = FindObjectOfType<SpritesTruco>();
    }
    void Start()
    {
        //int random1 = Random.Range(1, sprites.spritesTruco.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
