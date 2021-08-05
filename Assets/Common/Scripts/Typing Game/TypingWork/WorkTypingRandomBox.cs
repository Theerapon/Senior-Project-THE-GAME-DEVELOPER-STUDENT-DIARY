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
    private CharacterStatusController characterStatusController;

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
        characterStatusController = CharacterStatusController.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
        if (characterStatusController != null)
        {
            score = (int)(((characterStatusController.CurrentCodingStatus * 1.8f) + (characterStatusController.Default_designStatus) + (characterStatusController.CurrentTestingStatus) + (characterStatusController.Default_artStats) + (characterStatusController.Default_soundStats) / 10));
        }
        else
        {
            score = 200;
        }
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
