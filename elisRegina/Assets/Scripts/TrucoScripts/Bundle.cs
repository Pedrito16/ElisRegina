using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
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
    [SerializeField] GameObject vitoriaVerdadeira;
    private bool ativador = true;
    public UnityEvent soundEffect;
    public UnityEvent cardflip;
    public void Awake()
    {
        sprite = FindObjectOfType<SpritesTruco>();
        enemyScript = FindObjectOfType<EnemyAI>();
        vitoriaVerdadeira.SetActive(false);
        panel.SetActive(false);
    }
    public void OnDrop(PointerEventData data)
    {
        panel.SetActive(false);
        PlayerCard card = data.pointerDrag.GetComponent<PlayerCard>();
        Destroy(data.pointerDrag);
        cardflip.Invoke();
        gameObject.GetComponent<Image>().sprite = sprite.spritesTruco[card.cardStrength];
        playerStrength = card.cardStrength;
        currentTurn = gameState.enemyTurn;
        enemyScript.mudarTurno = true;
        enemyScript.startTurn();
    }
    void LateUpdate()
    {
        if(enemyStrength > 0 && playerStrength > 0 && ativador)
        {
            if(enemyStrength < playerStrength)
            {
                panel.SetActive(true);
                winText.color = Color.green;
                winText.text = "Vitoria!!!";
                RodadasSystem.ganhou++;
                RodadasSystem.rodadaAtual++;
                explainText.text = "Ganhou a " + RodadasSystem.rodadaAtual.ToString() + "º Rodada";
                ganhou = true;
                Time.timeScale = 0f;
                ativador = false;
            }else if(enemyStrength > playerStrength)
            {
                panel.SetActive(true);
                winText.color = Color.red;
                winText.text = "Derrota.";
                RodadasSystem.perdeu++;
                RodadasSystem.rodadaAtual++;
                explainText.text = "Perdeu a " + RodadasSystem.rodadaAtual.ToString() + "º Rodada";
                perdeu = true;
                Time.timeScale = 0f;
                ativador = false;
            }
        }
        if(RodadasSystem.perdeu >= 2)
        {
            
        }else if(RodadasSystem.ganhou >= 2)
        {
            panel.SetActive(false);
            vitoriaVerdadeira.SetActive(true);
            Time.timeScale = 0f;
            soundEffect.Invoke();
        }
    }
    public void VoltarBTN()
    {
        SceneManager.LoadScene("Bar");
        Time.timeScale = 1f;
    }
}
