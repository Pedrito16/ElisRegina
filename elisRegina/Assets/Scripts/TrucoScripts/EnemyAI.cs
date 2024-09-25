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
    int card1, card2;
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
        ativador = false;
        sprites = FindObjectOfType<SpritesTruco>();
        imageAnimator.gameObject.SetActive(false);
        turnTextAnimator.gameObject.SetActive(false);
    }
    void Start()
    {
        mudarTurno = true;
        card1 = Random.Range(1, sprites.spritesTruco.Length);
        card2 = Random.Range(1, sprites.spritesTruco.Length);
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
    // Update is called once per frame
    void Update()
    {
        
        if(currentState == gameState.enemyTurn && mudarTurno)
        {
            StartCoroutine(turnAnimation());
            turnText.color = Color.red;
            turnText.text = text;
            mudarTurno = false;
        }
        
        int Escolha = Random.Range(1, 2);
        if(Escolha == 1 && ativador)
        {
            if (inventário.Contains(card1))
            {
                carta = Instantiate(cartaJogar, spawnLocation.position, bundleTransform.rotation);
                carta.transform.SetParent(spawnLocation, false);
                carta.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card1];
                inventário.Remove(card1);
            }
            if(carta !=  null)
            {
                carta.transform.position = Vector3.MoveTowards(carta.transform.position, bundleTransform.position, speed);
            }
            if(carta.transform.position == bundleTransform.position && carta != null)
            {
                carta.SetActive(false);
                bundle.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card1];
                Destroy(carta);
            }
        }
        else if(Escolha == 2 && ativador)
        {
            carta = Instantiate(cartaJogar, spawnLocation.position, bundleTransform.rotation);
            carta.transform.SetParent(spawnLocation, false);
            carta.GetComponent<UnityEngine.UI.Image>().sprite = sprites.spritesTruco[card2];
            inventário.Remove(card2);
        }
    }
    
}
