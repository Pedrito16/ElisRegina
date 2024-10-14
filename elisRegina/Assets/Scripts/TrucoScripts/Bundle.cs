using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
    public bool ganhou, perdeu;
    public int enemyStrength = 0, playerStrength = 0;
    [Header("Tela De Vitoria ou Derrota")]
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI winText, explainText;
    public void Awake()
    {
        sprite = FindObjectOfType<SpritesTruco>();
        enemyScript = FindObjectOfType<EnemyAI>();
        panel.SetActive(false);
    }
    public void OnDrop(PointerEventData data)
    {
        panel.SetActive(false);
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
                panel.SetActive(true);
                winText.color = Color.green;
                winText.text = "Vitoria!!!";
                explainText.text = "Ganhou a Primeira Rodada";
                RodadasSystem.ganhou++;
                ganhou = true;
                Time.timeScale = 0f;
            }else if(enemyStrength > playerStrength)
            {
                panel.SetActive(true);
                winText.color = Color.red;
                winText.text = "Derrota.";
                explainText.text = "Perdeu a Primeira Rodada";
                RodadasSystem.perdeu++;
                perdeu = true;
                Time.timeScale = 0f;
            }
        }
    }
}
