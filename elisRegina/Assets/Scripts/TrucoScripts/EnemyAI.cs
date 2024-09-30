using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform canva, spawnLocation;
    [SerializeField] GameObject carta;
    [SerializeField] GameObject[] cartaVerso;
    [SerializeField] float speed;
    [SerializeField] Transform bundleTransform;
    [SerializeField] List<int> inventário;
    [SerializeField] Bundle bundleScript;
    [SerializeField] PlayerTurnController turnController;
    int card1, card2, card3;
    public int escolha;
    public GameObject cartaJogar;
    [SerializeField] SpritesTruco sprites;
    public GameObject bundle;
    [SerializeField] bool ativador;
    [Header("Animação Turnos")]
    public Animator imageAnimator, turnTextAnimator;
    public gameState currentState;
    [SerializeField] string text;
    public TextMeshProUGUI turnText;
    public bool mudarTurno;
    private void Awake()
    {
        imageAnimator.gameObject.SetActive(false);
        turnTextAnimator.gameObject.SetActive(false);
        turnController = FindObjectOfType<PlayerTurnController>();
        ativador = false;
        sprites = FindObjectOfType<SpritesTruco>();
        bundleScript = FindObjectOfType<Bundle>();
        imageAnimator.gameObject.SetActive(false);
        turnTextAnimator.gameObject.SetActive(false);
    }
    void Start()
    {
        startTurn();
    }
    public void startTurn()
    {
        carta = Instantiate(cartaJogar, spawnLocation.position, bundleTransform.rotation);
        carta.transform.SetParent(spawnLocation, false);
        carta.SetActive(false);
        mudarTurno = true;
        escolha = Random.Range(0, 2);
        card1 = Random.Range(1, sprites.spritesTruco.Length + 1);
        card2 = Random.Range(1, sprites.spritesTruco.Length + 1);
        inventário.Add(card1);
        inventário.Add(card2);
    }
    public IEnumerator turnAnimation()
    {
        imageAnimator.gameObject.SetActive(true);
        turnTextAnimator.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.80f);
        imageAnimator.gameObject.SetActive(false);
        turnTextAnimator.gameObject.SetActive(false);
        ativador = true;
    }
    void Update()
    { 
        if(bundleScript.currentTurn == gameState.enemyTurn && mudarTurno)
        {
            StartCoroutine(turnAnimation());
            turnText.color = Color.red;
            turnText.text = text;
            mudarTurno = false;
        }
        if(escolha == 0 && ativador)
        {
            if (inventário.Contains(card1))
            {
                carta.SetActive(true);
                carta.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card1];
                inventário.Remove(card1);
            }
            if(carta !=  null && isActiveAndEnabled)
            {
                carta.transform.position = Vector3.MoveTowards(carta.transform.position, bundleTransform.position, speed);
            }
            if(carta.transform.position == bundleTransform.position && carta != null)
            {
                bundle.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card1];
                bundleScript.enemyStrength = card1;
                Destroy(cartaVerso[escolha]);
                EndTurn();
            }
        }
        else if(escolha == 1 && ativador)
        {
            if (inventário.Contains(card2))
            {
                carta.SetActive(true);
                carta.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card2];
                inventário.Remove(card2);
            }
            if (carta != null && isActiveAndEnabled)
            {
                carta.transform.position = Vector3.MoveTowards(carta.transform.position, bundleTransform.position, speed);
            }
            if (carta.transform.position == bundleTransform.position && carta != null)
            {
                bundle.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card2];
                bundleScript.enemyStrength = card2;
                Destroy(cartaVerso[escolha]);
                EndTurn();
            }
        }
    }
    void EndTurn()
    {
        carta.SetActive(false);
        carta.transform.position = spawnLocation.position;
        ativador = false;
        bundleScript.currentTurn = gameState.playerTurn;
        turnController.mudarTurno = true;
    }
}
