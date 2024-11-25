using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CreditsController : MonoBehaviour
{
    [SerializeField] Button[] bot�es;
    [SerializeField] GameObject criadoresTextos;
    [SerializeField] GameObject musicTexts;
    [SerializeField] GameObject creditsMenu;
    private void Start()
    {
        creditsMenu.SetActive(false);
    }
    void Update()
    {

    }
    public void Criadores()
    {
        bot�es[0].interactable = false;
        bot�es[1].interactable = true;
        musicTexts.SetActive(false);
        criadoresTextos.SetActive(true);
    }
    public void M�sicas()
    {
        bot�es[1].interactable = false;
        bot�es[0].interactable = true;
        criadoresTextos.SetActive(false);
        musicTexts.SetActive(true);
    }
}
