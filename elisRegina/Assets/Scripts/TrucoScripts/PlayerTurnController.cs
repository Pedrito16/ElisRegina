using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] string text;
    [SerializeField] Animator turnTextAnim, turnImageAnim;
    [SerializeField] Bundle bundleScript;
    public bool mudarTurno, podeComeçar;
    private void Awake()
    {
        bundleScript = FindObjectOfType<Bundle>();
        podeComeçar = false;
    }
    void Update()
    {
        if(bundleScript.currentTurn == gameState.playerTurn && mudarTurno)
        {
            turnText.color = Color.blue;
            turnText.text = text;
            StartCoroutine(ChangeTurnAnimator());
            mudarTurno = false;
        }
    }
    IEnumerator ChangeTurnAnimator()
    {
        turnTextAnim.gameObject.SetActive(true);
        turnImageAnim.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.80f);
        turnTextAnim.gameObject.SetActive(false);
        turnImageAnim.gameObject.SetActive(false);
        podeComeçar = true;
    }
}
