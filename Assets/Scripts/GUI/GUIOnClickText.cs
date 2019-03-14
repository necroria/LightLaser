using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class GUIOnClickText : MonoBehaviour, IPointerClickHandler
{
    public Text text;
    public event UnityAction OnClickEvent;
    private bool onEvent = true;

    public bool OnEvent
    {
        get
        {
            return onEvent;
        }

        set
        {
            onEvent = value;
            if (value)
            {
                text.color = MyColor.DEFAULT;

            }
            else
            {
                
                
                text.color = MyColor.UNENABLED;
                
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnEvent)
        {
            OnClickEvent();
        }
        
    }
    public void SetText(string text)
    {
        this.text.text = text;
    }
}
