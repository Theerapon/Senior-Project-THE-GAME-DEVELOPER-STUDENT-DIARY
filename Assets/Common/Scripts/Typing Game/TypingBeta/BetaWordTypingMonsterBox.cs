using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BetaTypingPlayerManager;

public class BetaWordTypingMonsterBox : WordBox
{
    #region Instace tag
    private const string INST_Player = "BetaPlayer";
    #endregion

    private float screenHalfWidth;
    private float screenHalfHeight;

    private BetaTypingManager wordManager;
    private BetaTypingPlayerManager playerManager;
    private BetaTypingGameBossManager bossManager;

    [SerializeField] private float speed;
    [SerializeField] private GameObject shootingPosition;
    [SerializeField] private Image _bg;
    [SerializeField] private Color _bgUpgrade;
    

    private Vector3 normalizeDirection;

    private bool isCollision = false;
    private bool finishWord;
    private bool outOffScreen = false;
    private bool hasActived = true;
    private const int TIMESCALE = 1;
    private string id;

    private float countTime;
    private const float INST_CountTime = 1.5f;
    public string Id { get => id; set => id = value; }

    private BaseWordBetaTypingMonster baseWord;

    protected void Start()
    {
        wordManager = BetaTypingManager.Instance;
        playerManager = BetaTypingPlayerManager.Instance;
        bossManager = BetaTypingGameBossManager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
        screenHalfHeight = wordManager.GetCanvasHeight() / 2;
        finishWord = false;
        Vector3 goalPosition = wordManager.PlayerPosition.transform.position;
        normalizeDirection = (this.transform.position - goalPosition).normalized;

    }


    private void Update()
    {
        if (!outOffScreen && hasActived)
        {
            transform.position -= normalizeDirection * speed * Time.deltaTime;
            if (transform.position.x < -screenHalfWidth || transform.position.x > screenHalfWidth
                || transform.position.y <- screenHalfHeight || transform.position.y > screenHalfHeight)
            {
                playerManager.TakeDamage();
                outOffScreen = true;
                hasActived = false;
                wordManager.DestroyWordFromList(this);
            }

            if (finishWord)
            {
                if(countTime > 0)
                {
                    countTime -= Time.deltaTime * Time.timeScale;
                }
                else
                {
                    RemoveWord();
                }
            }
        }
    }

    public void TakeDamage()
    {
        wordManager.RemoveWordFromList(this);
    }

    public Vector3 GetShootingPosition()
    {
        return shootingPosition.transform.position;
    }

    public void FinishWord(BaseWordBetaTypingMonster baseWord)
    {
        this.baseWord = baseWord;
        tmp_Text.gameObject.SetActive(false);
        _bg.gameObject.SetActive(false);
        finishWord = true;
        isCollision = false;
        outOffScreen = false;
        countTime = INST_CountTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case INST_Player:
                BetaTypingPlayerManager player = collision.gameObject.GetComponentInChildren<BetaTypingPlayerManager>();
                if (player.HasAlive())
                {
                    player.TakeDamage();
                    hasActived = false;
                    finishWord = true;
                    isCollision = true;
                    wordManager.DestroyWordFromList(this);
                }
                break;
        }
    }

    public override void RemoveWord()
    {
        base.RemoveWord();        
        bossManager.MonsterDead();
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        playerManager.KillMonster();
    }
}
