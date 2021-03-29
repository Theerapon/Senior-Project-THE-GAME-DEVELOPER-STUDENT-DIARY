using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : Manager<ItemSaveManager>, ISaveable
{
    [SerializeField] ItemDatabase itemDatabase;

    private BagHandler player;
    private const string InventoryFileName = "Inventory";
    private const string EquipmentFileName = "Equipment";

    protected void Start()
    {
        //player = BagHandler.Instance;
        SaveManager.Instance.OnSaveInitiated.AddListener(HandleOnSave);
        //OnLoaded();
        
    }

    private void HandleOnSave()
    {
        OnSaved();
    }

    public void OnSaved()
    {
        SaveInventory();
        SaveEquipment();
    }

    public void OnLoaded()
    {
        LoadInventory();
        LoadEquipment();
    }

    private void SaveInventory()
    {
        //SaveItems(BagHandler.Instance.inv_container_handler.InvItemSlots, InventoryFileName);
    }

    private void SaveEquipment()
    {
        //SaveItems(BagHandler.Instance.Equipment.EquipmentSlots, EquipmentFileName);
    }

    private void LoadInventory()
    {   /*
        if (SaveLoad.SaveExists(InventoryFileName))
        {
            ItemContainerSaveData savedSlots = SaveLoad.Load<ItemContainerSaveData>(InventoryFileName);
            if (savedSlots == null) return;
            player.display_item_container.ClearItemSlots();

            for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
            {
                BaseInvSlot itemSlot = player.display_item_container.ItemSlots[i];
                ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

                if (savedSlot == null)
                {
                    itemSlot.ITEM = null;
                    //itemSlot.Amount = 0;
                }
                else
                {

                    Rigidbody itemSpawned = null;
                    ItemPickUp itemType = null;
                    Renderer itemMaterial = null;

                    ItemPickUp_Template itemsSO = itemDatabase.GetItemCopy(savedSlot.ItemID);
                    itemSpawned = Instantiate(itemsSO.GetItemRigidbody());
                    itemMaterial = itemSpawned.GetComponent<Renderer>();
                    if (itemMaterial != null)
                        itemMaterial.material = itemsSO.GetItemMaterial();
                    itemType = itemSpawned.GetComponent<ItemPickUp>();
                    itemType.itemDefinition = itemsSO;

                    itemSlot.ITEM = itemType;
                    //itemSlot.Amount = savedSlot.Amount;
                    itemSlot.ITEM.SetGameObjectToFalse();
                }
            }

        }*/

    }

    public void LoadEquipment()
    {   /*
        if (SaveLoad.SaveExists(InventoryFileName))
        {
            ItemContainerSaveData savedSlots = SaveLoad.Load<ItemContainerSaveData>(EquipmentFileName);
            if (savedSlots == null) return;

            foreach (ItemSlotSaveData savedSlot in savedSlots.SavedSlots)
            {
                if (savedSlot == null)
                {
                    continue;
                }

                Rigidbody itemSpawned = null;
                ItemPickUp itemType = null;
                Renderer itemMaterial = null;

                ItemPickUp_Template itemsSO = itemDatabase.GetItemCopy(savedSlot.ItemID);
                itemSpawned = Instantiate(itemsSO.GetItemRigidbody());
                itemMaterial = itemSpawned.GetComponent<Renderer>();
                if (itemMaterial != null)
                    itemMaterial.material = itemsSO.GetItemMaterial();
                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = itemsSO;

                player.display_item_container.AddItem(itemType);
                player.Equip(itemType);
            }
        }*/       
    }

    private void SaveItems(IList<BaseInvSlot> itemSlots, string fileName)
    {
        var saveData = new ItemContainerSaveData(itemSlots.Count);

        for (int i = 0; i < saveData.SavedSlots.Length; i++)
        {
            BaseInvSlot itemSlot = itemSlots[i];

            if (itemSlot.ITEM == null)
            {
                saveData.SavedSlots[i] = null;
            }
            else
            {
                //saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.ITEM.itemDefinition.ID(), itemSlot.Amount);
            }
        }
        SaveData(saveData, fileName);
    }

    private void SaveData(ItemContainerSaveData saveData, string fileName)
    {
        SaveLoad.Save(saveData, fileName);
    }
}
