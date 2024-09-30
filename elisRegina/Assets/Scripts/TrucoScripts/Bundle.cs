using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    EnemyAI enemyScript;
    public gameState currentTurn;
    public int enemyStrength = 0, playerStrength = 0;
    public void Awake()
    {
        sprite = FindObjectOfType<SpritesTruco>();
        enemyScript = FindObjectOfType<EnemyAI>();
    }
    public void OnDrop(PointerEventData data)
    {
        PlayerCard card = data.pointerDrag.GetComponent<PlayerCard>();
        Destroy(data.pointerDrag);
        gameObject.GetComponent<Image>().sprite = sprite.spritesTruco[card.cardStrength];
        playerStrength = card.cardStrength;
        currentTurn = gameState.enemyTurn;
        enemyScript.mudarTurno = true;
        enemyScript.startTurn();
    }
    void LateUpdate()
    {
        if(enemyStrength > 0 && playerStrength > 0)
        {
            if(enemyStrength < playerStrength)
            {
                RodadasSystem.ganhou++;
            }else if(enemyStrength > playerStrength)
            {

            }
        }
    }
}
public static class RodadasSystem
{
    public static int ganhou, perdeu;
}