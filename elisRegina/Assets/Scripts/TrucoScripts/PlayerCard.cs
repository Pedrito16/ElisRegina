using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayerCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public gameState currentState;
    public Bundle bundleScript;
    public SpritesTruco sprites;
    public PlayerTurnController turnControlScript;
    public int cardStrength = 0;
    bool ativador = true;
    Vector3 HoverPos, negativeHoverPos;
    Vector3 initialPos;
    [SerializeField] float hoverSpeed = 1f;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] string text;
    [SerializeField] Animator turnTextAnim, turnImageAnim;
    private void Awake()
    {
        bundleScript = FindObjectOfType<Bundle>();
        turnControlScript = FindObjectOfType<PlayerTurnController>();
        sprites = FindObjectOfType<SpritesTruco>();
        initialPos = transform.position;
        HoverPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        negativeHoverPos = new Vector3(transform.position.x, transform.position.y - 1.60f, transform.position.z);
    }
    void Start()
    {
        cardStrength = Random.Range(1, sprites.spritesTruco.Length);
        gameObject.GetComponent<Image>().sprite = sprites.spritesTruco[cardStrength];
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(bundleScript.currentTurn == gameState.playerTurn)
        {
            transform.position = Vector3.MoveTowards(HoverPos, initialPos, hoverSpeed * Time.deltaTime);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(bundleScript.currentTurn == gameState.playerTurn)
        {
            transform.position = Vector3.MoveTowards(initialPos, HoverPos, hoverSpeed * Time.deltaTime);
        }
    }
    void Update()
    {
        if(bundleScript.currentTurn == gameState.enemyTurn)
        {
            transform.position = negativeHoverPos;
        }
        else if(bundleScript.currentTurn == gameState.playerTurn && ativador)
        {
            transform.position = initialPos;
            ativador = false;
        }
    }
}
