using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingPlayerManager : Manager<BetaTypingPlayerManager>
{
    private CharacterStatusController characterStatusController;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Beta Typing")]
    [SerializeField] private BetaTypingManager betaTypingManager;
    [SerializeField] private RectTransform rectCanvas;
    private Vector3 positionShooting;

    private void Start()
    {
        positionShooting = betaTypingManager.PlayerPosition.transform.position;
    }

    public void Shooting(Vector3 positionTarget)
    {
        GameObject bullet = Instantiate(bulletPrefab, positionShooting, Quaternion.identity, rectCanvas);
        bullet.GetComponent<BetaTypingBullet>().Shooting(positionTarget, 200);
    }

    public void Shooting(Vector3 positionTarget, baseWord baseWord)
    {
        GameObject bullet = Instantiate(bulletPrefab, positionShooting, Quaternion.identity, rectCanvas);
        bullet.GetComponent<BetaTypingBullet>().Shooting(positionTarget, 200, baseWord);
    }
}
