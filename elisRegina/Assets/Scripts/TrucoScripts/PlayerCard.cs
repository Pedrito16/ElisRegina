using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SpritesTruco sprites;
    public int cardStrength = 0;
    Vector3 HoverPos;
    Vector3 initialPos;
    [SerializeField] float hoverSpeed = 1f;
    private void Awake()
    {
        sprites = FindObjectOfType<SpritesTruco>();
        initialPos = transform.position;
        HoverPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
    void Start()
    {
        cardStrength = Random.Range(1, sprites.spritesTruco.Length);
        gameObject.GetComponent<Image>().sprite = sprites.spritesTruco[cardStrength];
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position = Vector3.MoveTowards(HoverPos, initialPos, hoverSpeed * Time.deltaTime);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = Vector3.MoveTowards(initialPos, HoverPos, hoverSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
