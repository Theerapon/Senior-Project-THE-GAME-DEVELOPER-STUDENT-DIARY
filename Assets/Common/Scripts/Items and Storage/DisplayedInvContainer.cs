using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayedInvContainer : MonoBehaviour
{
    protected GameObject found_player;
    protected InventoryContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseInvSlot> ItemSlots;

    private void Start()
    {
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<InventoryContainer>();
        ItemSlots = new List<BaseInvSlot>();

        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

        Reset();
    }

    private void Reset()
    {
        DisplayedInv();
    }

    public void DisplayedInv()
    {
        for (int i = 0; i < container.container_item_entry.Length; i++)
        {
            ItemEntry itemEntry = container.container_item_entry[i];
            if (itemEntry != null)
            {
                ItemSlots[i].ITEM = itemEntry.item_entry;
            }
            else
            {
                ItemSlots[i].ITEM = null;
            }
        }

    }

}
