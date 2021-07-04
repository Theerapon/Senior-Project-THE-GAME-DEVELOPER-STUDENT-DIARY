using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BaseGiftArea : MonoBehaviour, IDropHandler
{
    public Events.EventOnDropItemToGiftArea OnDropItemToGiftArea;

    public void OnDrop(PointerEventData eventData)
    {
        OnDropItemToGiftArea?.Invoke();
    }
}
