using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour, ISaveable
{
    [SerializeField] ItemDatabase itemDatabase;
    private CharacterInventory characterInventory = null;
    private const string InventoryFileName = "Inventory";

    void Awake()
    {
        if(CharacterInventory.instance != null)
        {
            characterInventory = CharacterInventory.instance;
        }

        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSaveInitiated.AddListener(HandleOnSave);
        }


        OnLoaded();
    }

    private void HandleOnSave()
    {
        OnSaved();
    }

    public void OnSaved()
    {
        SaveInventory();
    }

    public void OnLoaded()
    {
        LoadInventory();
    }

    private void SaveInventory()
    {
        SaveItems(CharacterInventory.instance.itemsInInventory, InventoryFileName);
    }

    private void LoadInventory()
    {
        if (SaveLoad.SaveExists(InventoryFileName))
        {
            ItemContainerSaveData savedSlots = SaveLoad.Load<ItemContainerSaveData>(InventoryFileName);
            if (savedSlots == null) return;
            characterInventory.ResetInInventory();

            for (int countID = 0; countID < savedSlots.SavedSlots.Length; countID++)
            {
                //itemsInInventory.Add(idCount, new InventoryEntry(itemEntry.stackSize, Instantiate(itemEntry.invEntry), itemEntry.hbSprite));

                ItemSlotSaveData savedSlot = savedSlots.SavedSlots[countID];
                if (savedSlot == null)
                {

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

                    characterInventory.itemsInInventory.Add(countID, new InventoryEntry(savedSlot.stackSize, Instantiate(itemType), itemsSO.itemIcon, savedSlot.inventorySlot, savedSlot.hotBarSlot));
                    DestroyObject(itemType.gameObject);


                }
            }
        }

    }

    private void SaveItems(Dictionary<int, InventoryEntry> itemsInInventory, string fileName)
    {
        var saveData = new ItemContainerSaveData(itemsInInventory.Count);
        int count = 0;
        foreach (KeyValuePair<int, InventoryEntry> ie in itemsInInventory)
        {
            InventoryEntry inventory = ie.Value;

            if(inventory.invEntry == null)
            {
                saveData.SavedSlots[count] = null;
            }else
            {
                saveData.SavedSlots[count] = new ItemSlotSaveData(inventory.invEntry.itemDefinition.ID, inventory.stackSize, inventory.inventorySlot, inventory.hotBarSlot);
            }

            count++;
        }
        SaveData(saveData, fileName);
    }

    private void SaveData(ItemContainerSaveData saveData, string fileName)
    {
        SaveLoad.Save(saveData, fileName);
    }
}
