using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class itemSlot : MonoBehaviour,IDropHandler
{

    public List<GameObject> pictureDragged;
   public void OnDrop(PointerEventData eventData){
       if(eventData.pointerDrag != null){
           eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
           Debug.Log(eventData.pointerDrag.name);
           pictureDragged.Clear();
           pictureDragged.Add(eventData.pointerDrag.gameObject);
       }
   }
}
