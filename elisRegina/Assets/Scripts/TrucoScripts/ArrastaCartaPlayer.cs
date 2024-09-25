using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrastaCartaPlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CanvasGroup cartasConfigs;
    public gameState currentState;
    public RectTransform transformDaCarta;
    public float canvasScaleFactor;
    Vector3 transformDaCartaInicial;
    public void Awake()
    {
        cartasConfigs = GetComponent<CanvasGroup>();
        transformDaCarta = GetComponent<RectTransform>();
        transformDaCartaInicial = transformDaCarta.position;
        canvasScaleFactor = GetComponentInParent<Canvas>().scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentState == gameState.playerTurn)
        {
            cartasConfigs.alpha = 0.8f;
            cartasConfigs.blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(currentState == gameState.playerTurn)
        {
            transformDaCarta.anchoredPosition += eventData.delta / canvasScaleFactor;
        }
        else
        {
            eventData.dragging = false;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(currentState == gameState.playerTurn)
        {
            cartasConfigs.alpha = 1f;
            transformDaCarta.transform.position = transformDaCartaInicial;
            cartasConfigs.blocksRaycasts = true;
        }
    }
    void Update() 
    {
     if(currentState == gameState.enemyTurn)
     {
            gameObject.GetComponent<Image>().color = Color.gray;
            cartasConfigs.interactable = false;
     }else if(currentState == gameState.playerTurn)
        {
            cartasConfigs.interactable = true;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
