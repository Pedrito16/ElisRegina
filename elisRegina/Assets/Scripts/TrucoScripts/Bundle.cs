using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum gameState
{
    enemyTurn,
    playerTurn
}
public class Bundle : MonoBehaviour, IDropHandler
{
    public SpritesTruco sprite;
    public gameState currentTurn;
    public int enemyStrength = 0, playerStrength = 0;
    public void Awake()
    {
        sprite = FindObjectOfType<SpritesTruco>();
    }
    public void OnDrop(PointerEventData data)
    {
        PlayerCard card = data.pointerDrag.GetComponent<PlayerCard>();
        Destroy(data.pointerDrag);
        gameObject.GetComponent<Image>().sprite = sprite.spritesTruco[card.cardStrength];
        playerStrength = card.cardStrength;
    }
}
