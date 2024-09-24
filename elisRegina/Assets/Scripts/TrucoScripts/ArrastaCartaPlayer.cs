using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastaCartaPlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CanvasGroup cartasConfigs;
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
        cartasConfigs.alpha = 0.8f;
        cartasConfigs.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transformDaCarta.anchoredPosition += eventData.delta / canvasScaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        cartasConfigs.alpha = 1f;
        transformDaCarta.transform.position = transformDaCartaInicial;
        cartasConfigs.blocksRaycasts = true;
    }
}
