using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    [SerializeField] NotificationUpdateGenerator notificationUpdateGenerator;


    [SerializeField] private Sprite notificationSprite;

    [Header("Time notification")]
    private const string timeTitle = "เวลาไม่เพียงพอ";
    private const string timeDescription = "อย่าหักโหมสิ แบ่งเวลาสำหรับการพักผ่อนด้วย";

    [Header("Energy notification")]
    private const string energyTitle = "พลังงานไม่เพียงพอ";
    private const string energyDescription = "เหนื่อยเกินไปแล้ว พักผ่อนหน่อยนะ";

    [Header("Work Project Design notification")]
    private const string designDocumentTitle = "การออกแบบผิดพลาด";
    private const string projectNameDescription = "กรุณาตั้งชื่อโปรเจค";
    private const string goalIdeaDescription = "กรุณาเลือกเป้าหมายของตัวเกม";
    private const string mechanicIdeaDescription = "กรุณาเลือกกลไกหรือวิธีการเล่นของตัวเกม 2 รูปแบบ";
    private const string themeIdeaDescription = "กรุณาเลือกธีมของตัวเกม";

    public void EnergyNotEnough()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, energyTitle, energyDescription);
    }

    public void TimeNotEnough()
    {
        notificationUpdateGenerator.CreateTemplate(notificationSprite, timeTitle, timeDescription);
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
}
