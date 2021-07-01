using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUp_Template itemDefinition;

    StachContainer stach_container;
    InventoryContainer inventory_container;
    OtherBonusController otherBonusController;
    HardSkillsController hardSkillsController;
    CharacterStatusController characterStatusController;

    #region Constructors
    public ItemPickUp()
    {
        stach_container = StachContainer.Instance;
        inventory_container = InventoryContainer.Instance;
        otherBonusController = OtherBonusController.Instance;
        hardSkillsController = HardSkillsController.Instance;
        characterStatusController = CharacterStatusController.Instance;
    }
    public ItemPickUp(ItemPickUp_Template itemPickUp_Template)
    {
        itemDefinition = itemPickUp_Template;
        stach_container = StachContainer.Instance;
        inventory_container = InventoryContainer.Instance;
        otherBonusController = OtherBonusController.Instance;
        hardSkillsController = HardSkillsController.Instance;
        characterStatusController = CharacterStatusController.Instance;
    }
    #endregion

    public void StoreItem()
    {
        stach_container.StoreItem(this);
    }
    public void Selling()
    {
        DestroyItemPickUp();
    }
    public void PurchaseItem()
    {
        inventory_container.StoreItem(this);
    }

    public void UseItem()
    {
        List<ItemPropertyAmount> properties = new List<ItemPropertyAmount>();
        properties = itemDefinition.ItemProperties;
        int count = properties.Count;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                ItemPropertyType type = properties[i].PropertyType;
                float value = properties[i].Amount;
                switch (type)
                {
                    case ItemPropertyType.Energy:
                        characterStatusController.IncreaseCurrentEnergy(value);
                        break;
                    case ItemPropertyType.Motivation:
                        characterStatusController.IncreaseCurrentMotivation(value);
                        break;
                    case ItemPropertyType.StatusPoint:
                        characterStatusController.IncreaseStatusPoints((int)value);
                        break;
                    case ItemPropertyType.SoftSkillPoint:
                        characterStatusController.IncreaseSoftSkillPoints((int)value);
                        break;
                    case ItemPropertyType.CharacterExp:
                        characterStatusController.IncreaseEXP((int)value);
                        break;
                    case ItemPropertyType.HSMathExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Math_Id, (int)value);
                        break;
                    case ItemPropertyType.HSProgramingExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Programming_Id, (int)value);
                        break;
                    case ItemPropertyType.HSEngineExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Engine_Id, (int)value);
                        break;
                    case ItemPropertyType.HSNetworkExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Network_Id, (int)value);
                        break;
                    case ItemPropertyType.HSAiExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Ai_Id, (int)value);
                        break;
                    case ItemPropertyType.HSDesignExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Design_Id, (int)value);
                        break;
                    case ItemPropertyType.HSTesting:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Testing_Id, (int)value);
                        break;
                    case ItemPropertyType.HSArtExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Art_Id, (int)value);
                        break;
                    case ItemPropertyType.HSSoundExp:
                        hardSkillsController.IncreaseEXP(hardSkillsController.INST_Sound_Id, (int)value);
                        break;

                }
            }
        }
        DestroyItemPickUp();
    }
    public void Equip()
    {
        List<ItemPropertyAmount> properties = new List<ItemPropertyAmount>();
        properties = itemDefinition.ItemProperties;
        int count = properties.Count;
        if (count > 0)
        {
            for(int i = 0; i < count; i++)
            {
                ItemPropertyType type = properties[i].PropertyType;
                float value = properties[i].Amount;
                switch (type)
                {
                    case ItemPropertyType.Charm:
                        otherBonusController.IncreaseCharm(value);
                        break;
                    case ItemPropertyType.BonusProject:
                        otherBonusController.IncreaseReduceBugChance(value);
                        break;
                    case ItemPropertyType.BonusProjectGoldenTime:
                        otherBonusController.IncreaseBootupProjectInGoldenTime(value);
                        break;
                    case ItemPropertyType.BonusMotivation:
                        otherBonusController.IncreaseBootupMotivation(value);
                        break;
                    case ItemPropertyType.BonusMotivationGoldenTime:
                        otherBonusController.IncreaseBootupMotivationInGoldenTime(value);
                        break;
                    case ItemPropertyType.ReduceEnergyConsume:
                        otherBonusController.IncreaseEnergyConsume(value);
                        break;
                    case ItemPropertyType.ReduceEnergyConsumeGoldenTime:
                        otherBonusController.IncreaseEnergyConsumeInGoldenTime(value);
                        break;
                    case ItemPropertyType.ReduceChanceBug:
                        otherBonusController.IncreaseReduceBugChance(value);
                        break;
                    case ItemPropertyType.ReduceCourseTime:
                        otherBonusController.IncreaseReduceTimeCourse(value);
                        break;
                    case ItemPropertyType.ReduceTransportTime:
                        otherBonusController.IncreaseReduceTimeTransport(value);
                        break;
                    case ItemPropertyType.IncreaseDropRate:
                        otherBonusController.IncreaseDropRate(value);
                        break;
                    case ItemPropertyType.MaxEnergy:
                        otherBonusController.IncreaseMaxEnergy((int)value);
                        break;
                    case ItemPropertyType.Coding:
                        otherBonusController.IncreaseCodingStatus((int)value);
                        break;
                    case ItemPropertyType.Design:
                        otherBonusController.IncreaseDesignStatus((int)value);
                        break;
                    case ItemPropertyType.Testing:
                        otherBonusController.IncreaseTestingStatus((int)value);
                        break;
                    case ItemPropertyType.Art:
                        otherBonusController.IncreaseArtStatus((int)value);
                        break;
                    case ItemPropertyType.Sound:
                        otherBonusController.IncreaseSoundStatus((int)value);
                        break;
                }
            }
        }
    }

    public void Unequip()
    {
        List<ItemPropertyAmount> properties = new List<ItemPropertyAmount>();
        properties = itemDefinition.ItemProperties;
        int count = properties.Count;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                ItemPropertyType type = properties[i].PropertyType;
                float value = properties[i].Amount;
                switch (type)
                {
                    case ItemPropertyType.Charm:
                        otherBonusController.ReduceCharm(value);
                        break;
                    case ItemPropertyType.BonusProject:
                        otherBonusController.ReduceReduceBugChance(value);
                        break;
                    case ItemPropertyType.BonusProjectGoldenTime:
                        otherBonusController.ReduceBootupProjectInGoldenTime(value);
                        break;
                    case ItemPropertyType.BonusMotivation:
                        otherBonusController.ReduceBootupMotivation(value);
                        break;
                    case ItemPropertyType.BonusMotivationGoldenTime:
                        otherBonusController.ReduceBootupMotivationInGoldenTime(value);
                        break;
                    case ItemPropertyType.ReduceEnergyConsume:
                        otherBonusController.ReduceEnergyConsume(value);
                        break;
                    case ItemPropertyType.ReduceEnergyConsumeGoldenTime:
                        otherBonusController.ReduceEnergyConsumeInGoldenTime(value);
                        break;
                    case ItemPropertyType.ReduceChanceBug:
                        otherBonusController.ReduceReduceBugChance(value);
                        break;
                    case ItemPropertyType.ReduceCourseTime:
                        otherBonusController.ReduceReduceTimeCourse(value);
                        break;
                    case ItemPropertyType.ReduceTransportTime:
                        otherBonusController.ReduceReduceTimeTransport(value);
                        break;
                    case ItemPropertyType.IncreaseDropRate:
                        otherBonusController.ReduceDropRate(value);
                        break;
                    case ItemPropertyType.MaxEnergy:
                        otherBonusController.ReduceMaxEnergy((int)value);
                        break;
                    case ItemPropertyType.Coding:
                        otherBonusController.ReduceCodingStatus((int)value);
                        break;
                    case ItemPropertyType.Design:
                        otherBonusController.ReduceDesignStatus((int)value);
                        break;
                    case ItemPropertyType.Testing:
                        otherBonusController.ReduceTestingStatus((int)value);
                        break;
                    case ItemPropertyType.Art:
                        otherBonusController.ReduceArtStatus((int)value);
                        break;
                    case ItemPropertyType.Sound:
                        otherBonusController.ReduceSoundStatus((int)value);
                        break;
                }
            }
        }
    }

    public virtual void DestroyItemPickUp()
    {
        Destroy(this.gameObject);
    }

    public void SetGameObjectToTrue()
    {
        this.gameObject.SetActive(true);
    }

    public void SetGameObjectToFalse()
    {
        this.gameObject.SetActive(false);
    }

    #region Get
    public string Id { get => itemDefinition.Id; }
    public string ItemName { get => itemDefinition.ItemName; }
    public string ItemDescription { get => itemDefinition.ItemDescription; }
    public ItemDefinitionsType ItemType { get => itemDefinition.ItemType; }
    public ItemEquipmentType SubType { get => itemDefinition.SubType; }
    public int PurchasePrice { get => itemDefinition.PurchasePrice; }
    public int SellingPrice1 { get => itemDefinition.SellingPrice; }
    public Sprite ItemIcon { get => itemDefinition.ItemIcon; }
    public bool IsEquipped { get => itemDefinition.IsEquipped; }
    public bool IsStorable { get => itemDefinition.IsStorable; }
    public bool IsUseable { get => itemDefinition.IsUseable; }
    public bool IsDestroyOnUse { get => itemDefinition.IsDestroyOnUse; }
    public bool IsGiftable { get => itemDefinition.IsGiftable; }
    public List<ItemPropertyAmount> ItemProperties { get => itemDefinition.ItemProperties; }
    #endregion
}
