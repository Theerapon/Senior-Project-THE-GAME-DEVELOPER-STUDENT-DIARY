using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : Manager<ItemSaveManager>, ISaveable
{
    [SerializeField] ItemDatabase itemDatabase;

    private Player player = null;
    private const string InventoryFileName = "Inventory";
    private const string EquipmentFileName = "Equipment";

    protected override void Awake()
    {
        base.Awake();
        if(Player.instance != null)
        {
            player = Player.instance;
        }


        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSaveInitiated.AddListener(HandleOnSave);
        }
    }

    protected void Start()
    {
        OnLoaded();
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
        SaveItems(Player.instance.Inventory.ItemSlots, InventoryFileName);
    }

    private void SaveEquipment()
    {
        SaveItems(Player.instance.Equipment.EquipmentSlots, EquipmentFileName);
    }

    private void LoadInventory()
    {
        if (SaveLoad.SaveExists(InventoryFileName))
        {
            ItemContainerSaveData savedSlots = SaveLoad.Load<ItemContainerSaveData>(InventoryFileName);
            if (savedSlots == null) return;
            player.Inventory.ClearItemSlots();

            for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
            {
                ItemSlot itemSlot = player.Inventory.ItemSlots[i];
                ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

                if (savedSlot == null)
                {
                    itemSlot.ITEM = null;
                    itemSlot.Amount = 0;
                }
                else
                {

                    Rigidbody itemSpawned = null;
                    ItemPickUp itemType = null;
                    Renderer itemMaterial = null;

                    ItemPickUps_SO itemsSO = itemDatabase.GetItemCopy(savedSlot.ItemID);
                    itemSpawned = Instantiate(itemsSO.itemSpawnObject);
                    itemMaterial = itemSpawned.GetComponent<Renderer>();
                    if (itemMaterial != null)
                        itemMaterial.material = itemsSO.itemMaterial;
                    itemType = itemSpawned.GetComponent<ItemPickUp>();
                    itemType.itemDefinition = itemsSO;

                    itemSlot.ITEM = itemType;
                    itemSlot.Amount = savedSlot.Amount;
                    itemSlot.ITEM.SetGameObjectToFalse();
                }
            }

        }

    }

    public void LoadEquipment()
    {
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

                ItemPickUps_SO itemsSO = itemDatabase.GetItemCopy(savedSlot.ItemID);
                itemSpawned = Instantiate(itemsSO.itemSpawnObject);
                itemMaterial = itemSpawned.GetComponent<Renderer>();
                if (itemMaterial != null)
                    itemMaterial.material = itemsSO.itemMaterial;
                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = itemsSO;

                player.Inventory.AddItem(itemType);
                player.Equip(itemType);
            }
        }       
    }

    private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
    {
        var saveData = new ItemContainerSaveData(itemSlots.Count);

        for (int i = 0; i < saveData.SavedSlots.Length; i++)
        {
            ItemSlot itemSlot = itemSlots[i];

            if (itemSlot.ITEM == null)
            {
                saveData.SavedSlots[i] = null;
            }
            else
            {
                saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.ITEM.itemDefinition.ID, itemSlot.Amount);
            }
        }
        SaveData(saveData, fileName);
    }

    private void SaveData(ItemContainerSaveData saveData, string fileName)
    {
        SaveLoad.Save(saveData, fileName);
    }
}
