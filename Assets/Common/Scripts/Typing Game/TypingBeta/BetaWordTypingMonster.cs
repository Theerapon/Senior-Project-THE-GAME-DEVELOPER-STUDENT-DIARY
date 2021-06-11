using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BetaTypingPlayerManager;

public class BetaWordTypingMonster : WordBox
{
    #region Instace tag
    private const string INST_Player = "BetaPlayer";
    #endregion

    private float screenHalfWidth;
    private float screenHalfHeight;

    private BetaTypingManager wordManager;
    private BetaTypingPlayerManager playerManager;

    [SerializeField] private float speed;
    [SerializeField] private GameObject shootingPosition;
    [SerializeField] private Image _bg;
    [SerializeField] private Color _bgUpgrade;

    private Vector3 normalizeDirection;

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
                wordManager.RemoveWordFromList(this);
            }

            if (finishWord)
            {
                if(countTime > 0)
                {
                    countTime -= Time.deltaTime * Time.timeScale;
                }
                else
                {
                    SetWordAgain();
                }
            }
        }
    }

    public void TakeDamage(int damage, baseWord baseWord)
    {
        baseWord.RemoveWord();
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
        countTime = INST_CountTime;
    }

    private void SetWordAgain()
    {
        Upgrade();
        string word = WordGenerater.GetRandomWord();
        baseWord.ResetWord(word);
        wordManager.AddWordToList(baseWord);
        SetWord(word);
        finishWord = false;
        _bg.gameObject.SetActive(true);
        tmp_Text.gameObject.SetActive(true);

    }

    private void Upgrade()
    {
        speed *= 1.8f;
        _bg.color = _bgUpgrade;
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
                    wordManager.RemoveWordFromList(this);
                }
                break;
        }
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        playerManager.KillMonster();
    }
}
