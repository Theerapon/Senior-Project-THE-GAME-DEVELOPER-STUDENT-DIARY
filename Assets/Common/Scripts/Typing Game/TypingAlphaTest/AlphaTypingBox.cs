using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTypingBox : WordBox
{
    private float screenHalfWidth;
    private Vector3 normalizeDirection;

    private enum MoveDirection
    {
        Left,
        Right
    }
    private MoveDirection moveDirection;
    private bool outOffScreen = false;

    private AlphaTypingManager wordManager;
    private AlphaTypingPlayerManager playerManager;
    private CharacterStatusController characterStatusController;
    private int wordLength;
    private int score;
    private const int TIMESCALE = 1;

    [SerializeField] private float speed = 30f;

    private string id;

    public void setMoveDirection(bool isRight)
    {
        if (isRight)
        {
            moveDirection = MoveDirection.Right;
        }
        else
        {
            moveDirection = MoveDirection.Left;
        }
    }

    protected void Start()
    {
        wordManager = AlphaTypingManager.Instance;
        playerManager = AlphaTypingPlayerManager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
        //score = (int)(((characterStatusController.CurrentCodingStatus * 1.2f) + (characterStatusController.CurrentTestingStatus * 2f) / 10));
        score = 18;
        wordLength = tmp_Text.text.Length;
        Debug.Log("; " + wordLength);
    }

    private void Update()
    {
        if (!outOffScreen)
        {
            switch (moveDirection)
            {
                case MoveDirection.Left:
                    transform.position += normalizeDirection * speed * Time.deltaTime;
                    if (transform.position.x < -screenHalfWidth)
                    {
                        outOffScreen = false;
                        wordManager.OutOffScreen(this);
                    }
                    break;
                case MoveDirection.Right:
                    transform.position += normalizeDirection * speed * Time.deltaTime;
                    if (transform.position.x > screenHalfWidth)
                    {
                        outOffScreen = false;
                        wordManager.OutOffScreen(this);
                    }
                    break;
            }
        }


    }



    public void SetID(string id)
    {
        this.id = id;
    }

    public string GetID()
    {
        return id;
    }

    public void SetNormalizeDirection(Vector3 position)
    {
        normalizeDirection = (position - transform.position).normalized;
    }

    public void CreatedMonsterBox()
    {
        wordManager.AddWordMonsterBox(transform.position, normalizeDirection, (int)moveDirection);
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        wordManager.VerifiedWord();
        playerManager.IncreaseScore(score, wordLength);
        playerManager.IncreaseCombo();
    }
}
