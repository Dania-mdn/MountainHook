using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class iii: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        print("press");
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        print("offpress");
    }
}
