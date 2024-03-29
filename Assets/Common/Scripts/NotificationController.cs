﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : Manager<NotificationController>
{
    [SerializeField] NotificationUpdateGenerator notificationUpdateGenerator;

    [SerializeField] EmotionGenerator _parkGiftEmogenerator;
    [SerializeField] EmotionGenerator _shopGiftEmofenerator;

    [SerializeField] private Sprite notificationSprite;
    [SerializeField] private Color hasSpriteColor;
    [SerializeField] private Color defaultColor;

    [Header("Limit Char")]
    private const string limitChatTitle = "ครบลิมิตการคุยแล้ว";
    private const string limitChatDescription = "ครบลิมิตการคุยต่อกับ {0} แล้ว ไว้คุยต่อวันหลังนะ";

    [Header("Limit Gift")]
    private const string limitGiftTitle = "ครบลิมิตการให้ของขวัญแล้ว";
    private const string limitGiftDescription = "ครบลิมิตการให้ของขวัญกับ {0} แล้ว ไว้ให้วันหลังนะ";

    [Header("Idea")]
    private const string ideaTitle = "ปล็ดล็อค {0}";
    private const string ideaDescription = "ได้รับไอเดียใหม่ ๆ แล้ว อยากทำงานแล้วสิ";

    [Header("Class activity")]
    private const string classActivityTitle = "ยังนอนไม่ได้";
    private const string classActivityDescription = "วันนี้มีคลาสที่ต้องเข้า ยังนอนไม่ได้นะ";

    [Header("Purchase Item")]
    private const string purchaseTitle = "เงินไม่เพียงพอ";
    private const string purchaseDescription = "เหมือนเงินจะไม่พอ ต้องหาเงินเพิ่มแล้วละ";

    [Header("Inventory Full")]
    private const string inventoryTitle = "กระเป๋ามีพื้นที่ไม่เพียงพอ";
    private const string inventoryDescription = "เหมือนกระเป๋าจะเต็มนะ ต้องจัดระเบียบหน่อยแล้วละ";

    [Header("Time notification")]
    private const string timeTransportTitle = "เวลาไม่เพียงพอ";
    private const string timeTransportDescription = "นี่มันดึกมากแล้ว กลับบ้านพักผ่อนก่อนเถอะนะ";

    [Header("Energy notification")]
    private const string energyTransportTitle = "พลังงานไม่เพียงพอ";
    private const string energyTransportDescription = "เหนื่อยแล้วใช่ไหมละ กลับบ้านพักผ่อนเถอะนะ";

    [Header("Time notification")]
    private const string timeTitle = "เวลาไม่เพียงพอ";
    private const string timeDescription = "อย่าหักโหมสิ แบ่งเวลาสำหรับการพักผ่อนด้วยนะ";
    private const string timeProjectDayDescription = "เหมือนวันนี้จะมีคลาสที่มหาลัยนะ จะเข้าคลาสไม่ทันเอา";

    [Header("Energy notification")]
    private const string energyTitle = "พลังงานไม่เพียงพอ";
    private const string energyDescription = "เหนื่อยเกินไปแล้ว พักผ่อนหน่อยนะ";

    [Header("Work Project Design notification")]
    private const string designDocumentTitle = "การออกแบบผิดพลาด";
    private const string projectNameDescription = "กรุณาตั้งชื่อโปรเจค";
    private const string goalIdeaDescription = "กรุณาเลือกเป้าหมายของตัวเกม";
    private const string mechanicIdeaDescription = "กรุณาเลือกกลไกหรือวิธีการเล่นของตัวเกม 2 รูปแบบ";
    private const string themeIdeaDescription = "กรุณาเลือกธีมของตัวเกม";

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void EnergyNotEnoughForWork()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, energyTitle, energyDescription, defaultColor);
    }

    public void TimeNotEnoughForWorkOnProjectDay()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, timeTitle, timeProjectDayDescription, defaultColor);
    }
    public void TimeNotEnoughForWork()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, timeTitle, timeDescription, defaultColor);
    }
    public void EnergyNotEnoughForTransport()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, energyTransportTitle, energyTransportDescription, defaultColor);
    }

    public void TimeNotEnoughForTransport()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, timeTransportTitle, timeTransportDescription, defaultColor);
    }

    public void ProjectNameIsEmtyp()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, projectNameDescription, defaultColor);
    }

    public void GoalIdeaIsEmpty()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, goalIdeaDescription, defaultColor);
    }
    public void MechanicIdeaIsEmpty()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, mechanicIdeaDescription, defaultColor);
    }
    public void ThemeIdeaIsEmpty()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, themeIdeaDescription, defaultColor);
    }

    public void MoneyNotEnough(BaseItemShopSlot itemShopSlot)
    {
        notificationUpdateGenerator.CreateTemplate(itemShopSlot.ITEMSHOP.ItemIcon, purchaseTitle, purchaseDescription, hasSpriteColor);
    }

    public void MoneyNotEnough(Sprite icon)
    {
        notificationUpdateGenerator.CreateTemplate(icon, purchaseTitle, purchaseDescription, hasSpriteColor);
    }

    public void InventoryFull()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, inventoryTitle, inventoryDescription, defaultColor);
    }

    public void SellingItem(BaseItemSellingSlot itemSellingSlot)
    {
        string itemName = itemSellingSlot.ITEMSHOP.ItemName;
        string title = string.Format("การขาย {0} สำเร็จ", itemName);
        string description = string.Format("ได้รับ {0} บาท จากการขาย {1}", itemSellingSlot.ITEMSHOP.ItemPrice, itemName);
        Sprite icon = itemSellingSlot.ITEMSHOP.ItemIcon;
        notificationUpdateGenerator.CreateTemplate(icon, title, description, hasSpriteColor);
    }

    public void HasEventToFinish()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, classActivityTitle, classActivityDescription, defaultColor);
    }

    public void LimitChat(Sprite icon, string nameNpc)
    {
        string description = string.Format(limitChatDescription, nameNpc);
        notificationUpdateGenerator.CreateTemplate(icon, limitChatTitle, description, hasSpriteColor);
    }

    public void RecieveIdea(string ideaName, Sprite icon)
    {
        string title = string.Format(ideaTitle, ideaName);
        notificationUpdateGenerator.CreateTemplate(icon, title, ideaDescription, hasSpriteColor);
    }

    public void Emotion(Sprite icon)
    {
        if(_gameManager.CurrentGameState == GameManager.GameState.PLACE && (_gameManager.CurrentGameScene == GameManager.GameScene.Place_Park || _gameManager.CurrentGameScene == GameManager.GameScene.Place_Teacher_Home))
        {
            _parkGiftEmogenerator.CreateTemplate(icon);
        }
        else
        {
            _shopGiftEmofenerator.CreateTemplate(icon);
        }
    }

    public void LimitGift(Sprite icon, string nameNpc)
    {
        string description = string.Format(limitGiftDescription, nameNpc);
        notificationUpdateGenerator.CreateTemplate(icon, limitGiftTitle, description, hasSpriteColor);
    }
}
