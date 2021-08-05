using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaWordBossBox : WordBox
{
    private BetaTypingManager wordManager;
    private BetaTypingPlayerManager playerManager;
    [SerializeField] private GameObject shootingPosition;

    protected void Start()
    {
        wordManager = BetaTypingManager.Instance;
        playerManager = BetaTypingPlayerManager.Instance;
    }

    public Vector3 GetShootingPosition()
    {
        return shootingPosition.transform.position;
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        playerManager.AttackBoss();
    }
}
