using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrastaCartaPlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CanvasGroup cartasConfigs;
    Bundle bundleScript;
    public gameState currentState;
    public RectTransform transformDaCarta;
    public float canvasScaleFactor;
    Vector3 transformDaCartaInicial;
    public void Awake()
    {
        bundleScript = FindObjectOfType<Bundle>();
        cartasConfigs = GetComponent<CanvasGroup>();
        transformDaCarta = GetComponent<RectTransform>();
        transformDaCartaInicial = transformDaCarta.position;
        canvasScaleFactor = GetComponentInParent<Canvas>().scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (bundleScript.currentTurn == gameState.playerTurn)
        {
            cartasConfigs.alpha = 0.8f;
            cartasConfigs.blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(bundleScript.currentTurn == gameState.playerTurn)
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
        if(bundleScript.currentTurn == gameState.playerTurn)
        {
            cartasConfigs.alpha = 1f;
            transformDaCarta.transform.position = transformDaCartaInicial;
            cartasConfigs.blocksRaycasts = true;
        }
    }
    void Update() 
    {
     if(bundleScript.currentTurn == gameState.enemyTurn)
     {
            gameObject.GetComponent<Image>().color = Color.gray;
            cartasConfigs.interactable = false;
     }else if(bundleScript.currentTurn == gameState.playerTurn)
        {
            cartasConfigs.interactable = true;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
