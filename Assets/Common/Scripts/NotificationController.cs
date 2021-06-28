using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : Manager<NotificationController>
{
    [SerializeField] NotificationUpdateGenerator notificationUpdateGenerator;


    [SerializeField] private Sprite notificationSprite;

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

    [Header("Energy notification")]
    private const string energyTitle = "พลังงานไม่เพียงพอ";
    private const string energyDescription = "เหนื่อยเกินไปแล้ว พักผ่อนหน่อยนะ";

    [Header("Work Project Design notification")]
    private const string designDocumentTitle = "การออกแบบผิดพลาด";
    private const string projectNameDescription = "กรุณาตั้งชื่อโปรเจค";
    private const string goalIdeaDescription = "กรุณาเลือกเป้าหมายของตัวเกม";
    private const string mechanicIdeaDescription = "กรุณาเลือกกลไกหรือวิธีการเล่นของตัวเกม 2 รูปแบบ";
    private const string themeIdeaDescription = "กรุณาเลือกธีมของตัวเกม";

    public void EnergyNotEnoughForWork()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, energyTitle, energyDescription);
    }

    public void TimeNotEnoughForWork()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, timeTitle, timeDescription);
    }
    public void EnergyNotEnoughForTransport()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, energyTransportTitle, energyTransportDescription);
    }

    public void TimeNotEnoughForTransport()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, timeTransportTitle, timeTransportDescription);
    }

    public void ProjectNameIsEmtyp()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, projectNameDescription);
    }

    public void GoalIdeaIsEmpty()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, goalIdeaDescription);
    }
    public void MechanicIdeaIsEmpty()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, mechanicIdeaDescription);
    }
    public void ThemeIdeaIsEmpty()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, designDocumentTitle, themeIdeaDescription);
    }

    public void MoneyNotEnough(BaseItemShopSlot itemShopSlot)
    {
        notificationUpdateGenerator.CreateTemplate(itemShopSlot.ITEMSHOP.ItemIcon, purchaseTitle, purchaseDescription);
    }

    public void InventoryFull()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, inventoryTitle, inventoryDescription);
    }
}
