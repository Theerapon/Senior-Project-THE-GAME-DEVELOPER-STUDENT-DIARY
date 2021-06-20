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
        Summary,
    }
    #endregion
    private TypingGameState typingGameState;

    #region Level
    [SerializeField] private int []typingLevel;
    [SerializeField] private string []nameLevel;
    #endregion
    private int currentLevel;

    private static int countTotalWordGenerate;
    private static int countWordVerified;
    private static int countFoundWordBug;

    public Dictionary<string, baseWord> mainWordlist;
    private bool hasActivedWord;


    private string activeID;
    private baseWord activeWord;

    [Header("Spawner position")]
    [SerializeField] private RectTransform canvas;
    [SerializeField] private AlphaTypingSpawner wordSpawner;
    [SerializeField] private AlphaTypingMonsterSpawner wordMonsterSpawner;

    [Header("Manager")]
    [SerializeField] private AlphaTypingTimer wordTypingAlphaTimer;
    [SerializeField] private AlphaTypingPlayerManager playerManager;
    [SerializeField] private WordStatistics wordStatistics;

    public int CountTotalWordGenerate { get => countTotalWordGenerate; }
    public int CountWordVerified { get => countWordVerified; }
    public int CountFoundWordBug { get => countFoundWordBug; }
    public int CurrentLevel { get => currentLevel; }

    protected override void Awake()
    {
        base.Awake();
        playerManager.OnAlphaTypingPlayerStateChange.AddListener(OnAlphaTypingPlayerStateChangeHandler);
        mainWordlist = new Dictionary<string, baseWord>();
        Initializing();
    }

    private void OnAlphaTypingPlayerStateChangeHandler(AlphaTypingPlayerManager.AlphaPlayerState state)
    {
        if (state == AlphaTypingPlayerManager.AlphaPlayerState.Dead || state == AlphaTypingPlayerManager.AlphaPlayerState.Timeout)
        {
            UpdateTypingGameState(TypingGameState.PostGame);
        }
    }

    private void Initializing()
    {
        UpdateTypingGameState(TypingGameState.PreGame);
        currentLevel = 0;
        countTotalWordGenerate = 0;
        countWordVerified = 0;
        countFoundWordBug = 0;
        OnCheckedWordUpdate?.Invoke();
    }

    public void AddWordBox()
    {
        baseWordAlphaTypingNormal word = new baseWordAlphaTypingNormal(WordGenerater.GetRandomWord(), wordSpawner);
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
        countTotalWordGenerate++;
    }
    public void AddWordMonsterBox(Vector3 currentPosition, Vector3 normalizeDirection, int isRight)
    {
        baseWordAlphaTypingMonster word = new baseWordAlphaTypingMonster(WordGenerater.GetRandomWord(), wordMonsterSpawner, currentPosition, normalizeDirection, isRight);
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
        countFoundWordBug++;
    }

    public void VerifiedWord()
    {
        countWordVerified++;
    }

    public void TypeLetterManager(char letter)
    {
        if (hasActivedWord)
        {
            //check each letter in word that has actived
            if (activeWord.GetNexLetter() == letter)
            {
                activeWord.TypeLetterEachWord();
                TypingCorrect();
            }
            else
            {
                TypingIncorrect();
                playerManager.ReduceCombo();
            }
        }
        else
        {
            bool found = false;
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
                    found = true;
                    TypingCorrect();
                    break;
                }
            }

            if (!found)
            {
                TypingIncorrect();
                playerManager.ReduceCombo();
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
        playerManager.TakeDamage();
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
        playerManager.TakeDamage();
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
                Time.timeScale = 1f;
                break;
            case TypingGameState.Playing:
                Time.timeScale = 1f;
                break;
            case TypingGameState.PostGame:
                Time.timeScale = 0f;
                break;
            case TypingGameState.Summary:
                Time.timeScale = 1f;
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

    private void TypingCorrect()
    {
        wordStatistics.WordIsCorrect();
    }

    private void TypingIncorrect()
    {
        wordStatistics.WordIsIncorrect();
    }
}
