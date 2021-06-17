using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    [SerializeField] NotificationUpdateGenerator notificationUpdateGenerator;

    [Header("Time notification")]
    [SerializeField] private Sprite timeIcon;
    private const string timeTitle = "เวลาไม่เพียงพอ";
    private const string timeDescription = "อย่าหักโหมสิ แบ่งเวลาสำหรับการพักผ่อนด้วย";

    [Header("Energy notification")]
    [SerializeField] private Sprite energyIcon;
    private const string energyTitle = "พลังงานไม่เพียงพอ";
    private const string energyDescription = "เหนื่อยเกินไปแล้ว พักผ่อนหน่อยนะ";

    public void EnergyNotEnough()
    {
        notificationUpdateGenerator.CreateTemplate(energyIcon, energyTitle, energyDescription);
    }

    public void TimeNotEnough()
    {
        notificationUpdateGenerator.CreateTemplate(timeIcon, timeTitle, timeDescription);
    }
}
