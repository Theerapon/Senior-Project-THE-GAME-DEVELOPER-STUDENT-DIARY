using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetaWordTypingMonster : WordBox
{
    private float screenHalfWidth;
    private float screenHalfHeight;

    private BetaTypingManager wordManager;
    [SerializeField] private float speed;
    [SerializeField] private GameObject shootingPosition;
    [SerializeField] private Image _bg;
    [SerializeField] private Color _bgUpgrade;

    private Vector3 normalizeDirection;

    private bool finishWord;
    private bool outOffScreen = false;
    private const int TIMESCALE = 1;
    private string id;

    private float countTime;
    private const float INST_CountTime = 1.5f;
    public string Id { get => id; set => id = value; }

    private BaseWordBetaTypingMonster baseWord;

    protected void Start()
    {
        wordManager = BetaTypingManager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
        screenHalfHeight = wordManager.GetCanvasHeight() / 2;
        finishWord = false;
        Vector3 goalPosition = wordManager.PlayerPosition.transform.position;
        normalizeDirection = (this.transform.position - goalPosition).normalized;

    }


    private void Update()
    {
        if (!outOffScreen)
        {
            transform.position -= normalizeDirection * speed * Time.deltaTime;
            if (transform.position.x < -screenHalfWidth || transform.position.x > screenHalfWidth
                || transform.position.y <- screenHalfHeight || transform.position.y > screenHalfHeight)
            {
                outOffScreen = true;
                wordManager.OutOffScreen(this);
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
}
