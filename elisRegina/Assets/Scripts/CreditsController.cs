using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CreditsController : MonoBehaviour
{
    [SerializeField] Button[] botões;
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
        botões[0].interactable = false;
        botões[1].interactable = true;
        musicTexts.SetActive(false);
        criadoresTextos.SetActive(true);
    }
    public void Músicas()
    {
        botões[1].interactable = false;
        botões[0].interactable = true;
        criadoresTextos.SetActive(false);
        musicTexts.SetActive(true);
    }
}
