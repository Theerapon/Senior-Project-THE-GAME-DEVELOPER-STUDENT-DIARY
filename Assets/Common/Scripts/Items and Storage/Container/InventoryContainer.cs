using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : ItemContainer<InventoryContainer>
{
    #region
    public Events.EventOnInventoryUpdated OnInventoryUpdated;
    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void NotificationEvents()
    {
        base.NotificationEvents();
        OnInventoryUpdated?.Invoke();

    }
}
