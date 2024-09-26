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
    [SerializeField] float speed;
    [SerializeField] Transform bundleTransform;
    [SerializeField] List<int> inventário;
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
    bool mudarTurno;
    private void Awake()
    {
        imageAnimator.gameObject.SetActive(false);
        turnTextAnimator.gameObject.SetActive(false);
        ativador = false;
        sprites = FindObjectOfType<SpritesTruco>();
        imageAnimator.gameObject.SetActive(false);
        turnTextAnimator.gameObject.SetActive(false);
    }
    void Start()
    {
        carta = Instantiate(cartaJogar, spawnLocation.position, bundleTransform.rotation);
        carta.transform.SetParent(spawnLocation, false);
        carta.SetActive(false);
        mudarTurno = true;
        escolha = Random.Range(1, 2);
        card1 = Random.Range(1, sprites.spritesTruco.Length + 1);
        card2 = Random.Range(1, sprites.spritesTruco.Length + 1);
        inventário.Add(card1);
        inventário.Add(card2);
    }
    IEnumerator turnAnimation()
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
        if(currentState == gameState.enemyTurn && mudarTurno)
        {
            StartCoroutine(turnAnimation());
            turnText.color = Color.red;
            turnText.text = text;
            mudarTurno = false;
        }
        if(escolha == 1 && ativador)
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
                carta.SetActive(false);
                bundle.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card1];
                carta.transform.position = spawnLocation.position;
                ativador = false;
            }
        }
        else if(escolha == 2 && ativador)
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
                carta.SetActive(false);
                bundle.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card2];
                carta.transform.position = spawnLocation.position;
                ativador = false;
            }
        }
    }
    
}
