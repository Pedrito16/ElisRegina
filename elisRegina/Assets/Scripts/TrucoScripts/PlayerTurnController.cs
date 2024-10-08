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
    public bool mudarTurno, podeComešar;
    private void Awake()
    {
        bundleScript = FindObjectOfType<Bundle>();
        podeComešar = false;
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
        podeComešar = true;
    }
}
