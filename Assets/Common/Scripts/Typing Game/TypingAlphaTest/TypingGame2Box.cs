using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGame2Box : WordBox
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

    private TypingGame2Manager wordManager;

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
        wordManager = TypingGame2Manager.Instance;
        screenHalfWidth = wordManager.GetCanvasWidth() / 2;
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
}
