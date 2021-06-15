using UnityEngine;

public class AlphaTypingMonsterBox : WordBox
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

    [SerializeField] private float speed = 80f;

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
        //score = (int)(((characterStatusController.CurrentCodingStatus * 2.8f) + (characterStatusController.CurrentTestingStatus * 3.5f) / 10));
        score = 30;
        wordLength = tmp_Text.text.Length;
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
                        wordManager.MonsterOutOffScreen(this);
                    }
                    break;
                case MoveDirection.Right:
                    transform.position += normalizeDirection * speed * Time.deltaTime;
                    if (transform.position.x > screenHalfWidth)
                    {
                        outOffScreen = false;
                        wordManager.MonsterOutOffScreen(this);
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

    public void SetNormalizeDirection(Vector3 normolized)
    {
        normalizeDirection = normolized;
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        playerManager.IncreaseScore(score, wordLength);
    }

}
