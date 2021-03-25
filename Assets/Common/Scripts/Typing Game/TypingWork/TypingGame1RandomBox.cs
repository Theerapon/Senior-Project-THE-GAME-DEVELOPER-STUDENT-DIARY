using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingGame1RandomBox : WordBox
{
    private float screenHalfWidth;

    private enum MoveDirection
    {
        Left,
        Right
    }
    private MoveDirection moveDirection;
    private bool outOffScreen = false;

    private TypingGame1Manager wordManager;

    private const int TIMESCALE = 1;

    [SerializeField] private float speed = 30f;

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
        wordManager = TypingGame1Manager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
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

}
