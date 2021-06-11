using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaWordBossBox : WordBox
{
    private BetaTypingManager wordManager;
    [SerializeField] private GameObject shootingPosition;

    protected void Start()
    {
        wordManager = BetaTypingManager.Instance;
    }

    private void Update()
    {
        
    }

    public Vector3 GetShootingPosition()
    {
        return shootingPosition.transform.position;
    }
}
