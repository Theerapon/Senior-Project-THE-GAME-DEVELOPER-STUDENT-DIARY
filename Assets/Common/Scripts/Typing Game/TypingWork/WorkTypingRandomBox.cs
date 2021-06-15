using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkTypingRandomBox : WordBox
{
    private float screenHalfWidth;

    private enum MoveDirection
    {
        Left,
        Right
    }
    private MoveDirection moveDirection;
    private bool outOffScreen = false;

    private WorkTypingPlayerManager playerManager;
    private WorkTypingManager wordManager;

    private const int TIMESCALE = 1;

    [SerializeField] private float speed;
    private int wordLength;
    private int score;
    private float multiply;

    private string id;

    public void setMoveDirection(bool isRight)
    {
        if (isRight)
        {
            moveDirection = MoveDirection.Right;
        } else
        {
            moveDirection = MoveDirection.Left;
        }
    }


    protected void Start()
    {
        wordManager = WorkTypingManager.Instance;
        playerManager = WorkTypingPlayerManager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
        //score = (int)(((characterStatusController.CurrentCodingStatus * 2.8f) + (characterStatusController.CurrentTestingStatus * 3.5f) / 10));
        score = 30;
        wordLength = tmp_Text.text.Length;
        multiply = playerManager.BoxGenerateMultiplier[(int)playerManager.ChancePhase];
    }

    private void Update()
    {
        if (!outOffScreen)
        {
            switch (moveDirection)
            {
                case MoveDirection.Left:
                    transform.Translate(new Vector3(-speed * Time.deltaTime * TIMESCALE, 0, 0));
                    if(transform.position.x < -screenHalfWidth)
                    {
                        outOffScreen = false;
                        wordManager.OutOffScreen(this);
                    }
                    break;
                case MoveDirection.Right:
                    transform.Translate(new Vector3(speed * Time.deltaTime * TIMESCALE, 0, 0));
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


    public override void TypedCompleted()
    {
        base.TypedCompleted();
        playerManager.IncreaseScore(score, wordLength, multiply);
    }

}
