using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEvent : MonoBehaviour
{
    [SerializeField] Text mouseEventText;

    [SerializeField] Image image;


    public void PointerEnter(BaseEventData _data)
    {
        mouseEventText.text = "PointerEnter, red";

        image.color = Color.red;

        Debug.Log("PointerEnter");
    }

    public void PointerExit(BaseEventData _data)
    {
        //mouseEventText.text = string.Format("{0} {1)", 1, "Exit");

        mouseEventText.text = "PointerExit, blue";

        image.color = Color.blue;

        Debug.Log("PointerExit");
    }

    public void PointerDown(BaseEventData _data)
    {
        mouseEventText.text = "PointerDown, green";

        image.color = Color.green;

        Debug.Log("PointerDown");
    }

    public void PointerUp(BaseEventData _data)
    {
        mouseEventText.text = "PointerUp, cyan";

        image.color = Color.cyan;

        Debug.Log("PointerUp");
    }

    public void PointerClick(BaseEventData _data)
    {
        mouseEventText.text = "PointerClick, black";

        image.color = Color.black;

        Debug.Log("PointerClick");
    }

    public void Drag(BaseEventData _data)
    {
        mouseEventText.text = "Drag, gray";

        image.color = Color.gray;

        Debug.Log("Drag");
    }

    public void Drop(BaseEventData _data)
    {
        mouseEventText.text = "Drop, grey";

        image.color = Color.grey;

        Debug.Log("Drop");
    }

    public void Scroll(BaseEventData _data)
    {
        mouseEventText.text = "Scoll, white";

        image.color = Color.white;

        Debug.Log("Scroll");
    }

    public void Move(BaseEventData _data)
    {
        mouseEventText.text = "Move, magenta";

        image.color = Color.magenta;

        Debug.Log("Move");
    }

    public void BeginDrag(BaseEventData _data)
    {
        mouseEventText.text = "BeginDrag, yellow";

        image.color = Color.yellow;

        Debug.Log("BeginDrag");
    }

    public void EndDrag(BaseEventData _data)
    {
        mouseEventText.text = "EndDrag, clear";

        image.color = Color.clear;

        Debug.Log("EndDrag");
    }

}
