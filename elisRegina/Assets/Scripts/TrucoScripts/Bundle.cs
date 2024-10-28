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
    [SerializeField] TextMeshProUGUI trueWinText;
    private bool ativador = true;
    private bool ativador2 = true;
    public UnityEvent soundEffect;
    public UnityEvent cardflip;
    [Header("dinheiroPlayer")]
    [SerializeField] int dinheiroPlayer;
    [Header("Coroa")]
    [SerializeField] Image coroa, voltarBTN;
    [SerializeField] Sprite[] coroaSprites;
    public void Awake()
    {
        sprite = FindObjectOfType<SpritesTruco>();
        enemyScript = FindObjectOfType<EnemyAI>();
        vitoriaVerdadeira.SetActive(false);
        panel.SetActive(false);
        dinheiroPlayer = PlayerPrefs.GetInt("Dinheiro");
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
        if(RodadasSystem.perdeu >= 2 && ativador2)
        {
            panel.SetActive(false);
            trueWinText.text = "Derrota!!";
            trueWinText.color = Color.red;
            coroa.sprite = coroaSprites[0];
            dinheiroPlayer = dinheiroPlayer - BetInfo.valorAposta;
            PlayerPrefs.SetInt("Dinheiro", dinheiroPlayer);
            voltarBTN.color = Color.red;
            vitoriaVerdadeira.SetActive(true);
            Time.timeScale = 1f;
            Invoke("VoltarBTN", 3f);
            ativador2 = false;
            RodadasSystem.rodadaAtual = 0;
        }
        else if(RodadasSystem.ganhou >= 2 && ativador2)
        {
            panel.SetActive(false);
            trueWinText.text = "Vitoria!!";
            trueWinText.color = Color.yellow;
            coroa.sprite = coroaSprites[1];
            dinheiroPlayer = dinheiroPlayer + BetInfo.valorAposta;
            PlayerPrefs.SetInt("Dinheiro", dinheiroPlayer);
            vitoriaVerdadeira.SetActive(true);
            soundEffect.Invoke();
            Invoke("VoltarBTN", 3f);
            Time.timeScale = 1f;
            ativador2 = false;
            RodadasSystem.rodadaAtual = 0;
        }
    }
    public void VoltarBTN()
    {
        Powers.canChangeLocation = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Bar");
    }
}
