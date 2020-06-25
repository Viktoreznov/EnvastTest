using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class dragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    void Awake()
    {
       rectTransform = GetComponent<RectTransform>(); 
       canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData){

    }
    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .7f;
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData){

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
