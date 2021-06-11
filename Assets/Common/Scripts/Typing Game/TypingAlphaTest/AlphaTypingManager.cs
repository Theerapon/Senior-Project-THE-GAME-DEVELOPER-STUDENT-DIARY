using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTypingManager : Manager<AlphaTypingManager>
{
    #region Events
    public Events.EventOnCheckedWordUpdate OnCheckedWordUpdate;
    public Events.EventOnAlphaTypingGameStateChanged OnTypingGameStateChanged;
    #endregion

    #region TypingGameState
    public enum TypingGameState
    {
        PreGame,
        Playing,
        PostGame,
    }
    #endregion
    private TypingGameState typingGameState;

    #region Level
    [SerializeField] private int []typingLevel;
    [SerializeField] private string []nameLevel;
    #endregion
    private int currentLevel;

    private int score;
    private int comboCount;

    public Dictionary<string, baseWord> mainWordlist;
    private bool hasActivedWord;


    private string activeID;
    private baseWord activeWord;

    [SerializeField] private RectTransform canvas;
    [SerializeField] private AlphaTypingSpawner wordSpawner;
    [SerializeField] private AlphaTypingMonsterSpawner wordMonsterSpawner;

    [SerializeField] private AlphaTypingTimer wordTypingAlphaTimer;

    protected override void Awake()
    {
        base.Awake();
        mainWordlist = new Dictionary<string, baseWord>();
    }
    private void Start()
    {
        UpdateTypingGameState(TypingGameState.PreGame);
        currentLevel = 0;
        OnCheckedWordUpdate?.Invoke();
    }

    public void AddWordBox()
    {
        baseWordAlphaTypingNormal word = new baseWordAlphaTypingNormal(WordGenerater.GetRandomWord(), wordSpawner);
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
    }
    public void AddWordMonsterBox(Vector3 currentPosition, Vector3 normalizeDirection, int isRight)
    {
        baseWordAlphaTypingMonster word = new baseWordAlphaTypingMonster(WordGenerater.GetRandomWord(), wordMonsterSpawner, currentPosition, normalizeDirection, isRight);
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
    }

    public void TypeLetterManager(char letter)
    {
        if (hasActivedWord)
        {
            //check each letter in word that has actived
            if (activeWord.GetNexLetter() == letter)
            {
                activeWord.TypeLetterEachWord();
            }
        }
        else
        {
            //check for index 0 each Word in wordList
            foreach (KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                if (eachWord.Value.GetNexLetter() == letter)
                {

                    activeID = eachWord.Key;
                    activeWord = eachWord.Value;
                    hasActivedWord = true;
                    eachWord.Value.TypeLetterEachWord();
                    eachWord.Value.UpdatedOrderLayer();
                    break;
                }
            }
        }

        if (hasActivedWord && activeWord.WordTypedEnd())
        {
            OnCheckedWordUpdate?.Invoke();
            hasActivedWord = false;
            activeWord.CreatedMonsterBox();
            mainWordlist.Remove(activeID);

            if(wordTypingAlphaTimer.GetAmountGenerator() != 0 && mainWordlist.Count <= 0)
            {
                wordTypingAlphaTimer.GeneratedBox();
            }

            if (wordTypingAlphaTimer.GetAmountGenerator() == 0 && mainWordlist.Count <= 0)
            {
                wordTypingAlphaTimer.LevelUp();
            }
        }
    }

    public void OutOffScreen(AlphaTypingBox typingGame2Box)
    {
        string id = typingGame2Box.GetID();

        if (activeWord != null)
        {
            if (mainWordlist[id].GetWord().Equals(activeWord.GetWord()) && hasActivedWord == true)
            {
                hasActivedWord = false;
            }
        }

        mainWordlist[id].RemoveWord();
        mainWordlist.Remove(id);
    }

    public void MonsterOutOffScreen(AlphaTypingMonsterBox typingGame2MonsterBox)
    {
        string id = typingGame2MonsterBox.GetID();

        if (activeWord != null)
        {
            if (mainWordlist[id].GetWord().Equals(activeWord.GetWord()) && hasActivedWord == true)
            {
                hasActivedWord = false;
            }
        }

        mainWordlist[id].RemoveWord();
        mainWordlist.Remove(id);
    }

    public float GetCanvasWidth()
    {
        return canvas.rect.width;
    }

    public void UpdateTypingGameState(TypingGameState typingGameState)
    {
        this.typingGameState = typingGameState;
        switch (typingGameState)
        {
            case TypingGameState.PreGame:
                Time.timeScale = 0f;
                break;
            case TypingGameState.Playing:
                Time.timeScale = 1f;
                break;
            case TypingGameState.PostGame:
                Time.timeScale = 0f;
                break;
        }
        OnTypingGameStateChanged?.Invoke(this.typingGameState);
    }

    public TypingGameState GetTypingGameState()
    {
        return typingGameState;
    }

    public void PlaysGame()
    {
        wordTypingAlphaTimer.PlaysGame();
    }

    public int GetAmountTypingLevel()
    {
        return typingLevel[currentLevel];
    }

    public void TypingLevelUp()
    {
        if(currentLevel < typingLevel.Length - 1)
        {
            currentLevel++;
            OnCheckedWordUpdate?.Invoke();
        }
    }

    public string GetNameLevel()
    {
        return nameLevel[currentLevel];
    }
}
