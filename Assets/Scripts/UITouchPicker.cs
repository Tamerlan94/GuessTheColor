using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITouchPicker : MonoBehaviour, IPointerDownHandler
{
    private Color _color;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Нажато с помощью интерфейса");
        _color = GetComponent<Image>().color;
        int random = UnityEngine.Random.Range(0, 2);
        bool dir = Convert.ToBoolean(random);
        PlatformSwitcher.instance.MovePlatform(dir, _color);
    }
        
}
