using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInventory : MonoBehaviour
{

    #region Variable Declarations
    public static CharacterInventory instance;

    //public CharacterStats charStats;
    //GameObject foundStats;

    [Header("Hotbar")]
    public Image[] hotBarDisplayHolders = new Image[12];

    [Header("Inventory")]
    public GameObject InventoryDisplayHolder;
    public Image[] inventoryDisplaySlots = new Image[60];

    private int inventoryItemCap = 60;
    private int idCount = 1;
    bool addedItem = true;

    public Dictionary<int, InventoryEntry> itemsInInventory = new Dictionary<int, InventoryEntry>();
    public InventoryEntry itemEntry;
    #endregion

    #region Initializations
    void Awake()
    {

        instance = this;
        ResetItemEntry();
        ResetInInventory();


        inventoryDisplaySlots = InventoryDisplayHolder.GetComponentsInChildren<Image>();
        FillInventoryDisplay();
        //foundStats = GameObject.FindGameObjectWithTag("Player");
        //charStats = foundStats.GetComponent<CharacterStats>();


    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerItemUse(101);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerItemUse(102);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerItemUse(103);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerItemUse(104);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerItemUse(105);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TriggerItemUse(106);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerItemUse(107);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerItemUse(108);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerItemUse(109);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TriggerItemUse(110);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            TriggerItemUse(111);
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            TriggerItemUse(112);
        }

        if (!addedItem)
        {
            TryPickUp();
        }

    }

    public void StoreItem(ItemPickUp itemToStore)
    {
        addedItem = false;

        itemEntry.invEntry = itemToStore;
        itemEntry.stackSize = 1;
        itemEntry.hbSprite = itemToStore.itemDefinition.itemIcon;

        //addedItem = false;
        itemToStore.gameObject.SetActive(false);
    }

    private void TryPickUp()
    {
        bool itsInInv = true;

        //Check to see if the item to be stored was properly submitted to the inventory - Continue if Yes otherwise do nothing
        if (itemEntry.invEntry)
        {
            //Check to see if any items exist in the inventory already - if not, add this item
            if (itemsInInventory.Count == 0)
            {
                addedItem = AddItemToInv(addedItem);
            }
            //If items exist in inventory
            else
            {
                //Check to see if the item is stackable - Continue if stackable
                if (itemEntry.invEntry.itemDefinition.isStackable)
                {
                    foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
                    {
                        //Does this item already exist in inventory? - Continue if Yes
                        if (itemEntry.invEntry.itemDefinition == ie.Value.invEntry.itemDefinition)
                        {
                            //Add 1 to stack and destroy the new instance
                            ie.Value.stackSize += 1;
                            AddItemToHotBar(ie.Value);
                            itsInInv = true;
                            DestroyObject(itemEntry.invEntry.gameObject);
                            break;
                        }
                        //If item does not exist already in inventory then continue here
                        else
                        {
                            itsInInv = false;
                        }
                    }
                }
                //If Item is not stackable then continue here
                else
                {
                    itsInInv = false;

                    //If no space and item is not stackable - say inventory full
                    if (itemsInInventory.Count == inventoryItemCap)
                    {
                        itemEntry.invEntry.gameObject.SetActive(true);
                        Debug.Log("Inventory is Full");
                    }
                }

                //Check if there is space in inventory - if yes, continue here
                if (!itsInInv)
                {
                    addedItem = AddItemToInv(addedItem);
                    itsInInv = true;
                }
            }
        }
    }
    private bool AddItemToInv(bool finishedAdding)
    {
        itemsInInventory.Add(idCount, new InventoryEntry(itemEntry.stackSize, Instantiate(itemEntry.invEntry), itemEntry.hbSprite));

        DestroyObject(itemEntry.invEntry.gameObject);

        FillInventoryDisplay();
        AddItemToHotBar(itemsInInventory[idCount]);

        idCount = IncreaseID(idCount);

        #region Reset itemEntry
        itemEntry.invEntry = null;
        itemEntry.stackSize = 0;
        itemEntry.hbSprite = null;
        #endregion

        finishedAdding = true;

        return finishedAdding;
    }

    private int IncreaseID(int currentID)
    {
        int newID = 1;

        for (int itemCount = 1; itemCount <= itemsInInventory.Count; itemCount++)
        {
            if (itemsInInventory.ContainsKey(newID))
            {
                newID += 1;
            }
            else return newID;
        }

        return newID;
    }
    private void AddItemToHotBar(InventoryEntry itemForHotBar)
    {
        int hotBarCounter = 0;
        bool increaseCount = false;

        //Check for open hotbar slot
        foreach (Image images in hotBarDisplayHolders)
        {
            hotBarCounter += 1;

            if (itemForHotBar.hotBarSlot == 0)
            {
                if (images.sprite == null)
                {
                    //Add item to open hotbar slot
                    itemForHotBar.hotBarSlot = hotBarCounter;
                    //Change hotbar sprite to show item
                    images.sprite = itemForHotBar.hbSprite;
                    increaseCount = true;
                    break;
                }
            }
            else if (itemForHotBar.invEntry.itemDefinition.isStackable)
            {
                increaseCount = true;
            }
        }

        if (increaseCount)
        {
            hotBarDisplayHolders[itemForHotBar.hotBarSlot - 1].GetComponentInChildren<TMP_Text>().text = itemForHotBar.stackSize.ToString();
        }

        increaseCount = false;
    }
    private void FillInventoryDisplay()
    {
        int slotCounter = 0;

        foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
        {
            slotCounter += 1;
            if(ie.Value.inventorySlot == 0)
            {
                inventoryDisplaySlots[slotCounter].sprite = ie.Value.hbSprite;
                ie.Value.inventorySlot = slotCounter;
            } else
            {
                inventoryDisplaySlots[ie.Value.inventorySlot].sprite = ie.Value.hbSprite;
            }

        }

        while (slotCounter < 60)
        {
            slotCounter++;
            inventoryDisplaySlots[slotCounter].sprite = null;
        }
    }
    public void TriggerItemUse(int itemToUseID)
    {
        bool triggerItem = false;

        foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
        {
            if (itemToUseID > 100)
            {
                itemToUseID -= 100;

                if (ie.Value.hotBarSlot == itemToUseID)
                {
                    triggerItem = true;
                }
            }
            else
            {
                if (ie.Value.inventorySlot == itemToUseID)
                {
                    triggerItem = true;
                }
            }

            if (triggerItem)
            {
                if (ie.Value.stackSize == 1)
                {
                    if (ie.Value.invEntry.itemDefinition.isStackable)
                    {
                        if (ie.Value.hotBarSlot != 0)
                        {
                            hotBarDisplayHolders[ie.Value.hotBarSlot - 1].sprite = null;
                            hotBarDisplayHolders[ie.Value.hotBarSlot - 1].GetComponentInChildren<TMP_Text>().text = "0";
                        }

                        ie.Value.invEntry.UseItem();
                        itemsInInventory.Remove(ie.Key);
                        break;
                    }
                    else
                    {
                        ie.Value.invEntry.UseItem();
                        if (!ie.Value.invEntry.itemDefinition.isDestructible)
                        {
                            itemsInInventory.Remove(ie.Key);
                            break;
                        }
                        break;
                    }
                }
                else
                {
                    ie.Value.invEntry.UseItem();
                    ie.Value.stackSize -= 1;
                    hotBarDisplayHolders[ie.Value.hotBarSlot - 1].GetComponentInChildren<TMP_Text>().text = ie.Value.stackSize.ToString();
                    break;
                }
            }
        }

        FillInventoryDisplay();
    }

    public void ResetInInventory()
    {
        itemsInInventory.Clear();
    }

    public void ResetItemEntry()
    {
        itemEntry = new InventoryEntry(0, null, null);
    }

}
