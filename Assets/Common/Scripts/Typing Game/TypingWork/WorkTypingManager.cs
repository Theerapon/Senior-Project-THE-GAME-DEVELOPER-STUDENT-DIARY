using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WorkTypingManager : Manager<WorkTypingManager>
{
    #region Events
    public Events.EventOnWorkTypingGameStateChanged OnTypingGameStateChanged;
    #endregion

    #region TypingGameState
    public enum TypingGameState
    {
        PreGame,
        Playing,
        PostGame,
        Summary
    }
    #endregion
    private TypingGameState typingGameState;

    public Dictionary<string, baseWord> mainWordlist;

    private bool hasActivedWord;
    private string activeID;
    private baseWord activeWord;
    private string mainID;
    private baseWord mainWord;

    [SerializeField] private RectTransform canvas;

    [Header("Position spawner")]
    [SerializeField] private WorkTypingMainSpawner wordMainSpawner;
    [SerializeField] private WorkTypingRandomSpawner wordRandomSpawner;
    
    [Header("Manager")]
    [SerializeField] private WorkTypingPlayerManager playerManager;
    [SerializeField] private WordStatistics wordStatistics;
    [SerializeField] private WorkTypingTimer wordTypingWorkTimer;

    public TypingGameState GetTypingGameState { get => typingGameState; }

    protected override void Awake()
    {
        base.Awake();
        mainWordlist = new Dictionary<string, baseWord>();
        playerManager.OnWorkTypingPlayerStateChange.AddListener(OnWorkTypingPlayerStateChangehandler);
        Initializing();
    }

    private void Initializing()
    {
        UpdateTypingGameState(TypingGameState.PreGame);
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

    private void OnWorkTypingPlayerStateChangehandler(WorkTypingPlayerManager.WorkPlayerState state)
    {
        if (state == WorkTypingPlayerManager.WorkPlayerState.Timeout)
        {
            UpdateTypingGameState(TypingGameState.PostGame);
        }
    }


    public void AddMainWordBox()
    {
        BaseWordWorkTypingGameMain word = new BaseWordWorkTypingGameMain(WordGenerater.GetRandomWord(), wordMainSpawner.SpawnWord());
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        mainWord = word;
        mainID = word.GetHashCode().ToString();


    }

    public void AddRandomWordBox()
    {
        BaseWordWorkTypingRandom word = new BaseWordWorkTypingRandom(WordGenerater.GetRandomWord(), wordRandomSpawner);
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
    }
    public void PlaysGame()
    {
        wordTypingWorkTimer.PlaysGame();
    }

    public void TypeLetterManager(char letter)
    {
        if (hasActivedWord)
        {
            //check each letter in word that has actived
            if(activeWord.GetNexLetter() == letter)
            {
                activeWord.TypeLetterEachWord();
                TypingCorrect();
            }
            else
            {
                TypingIncorrect();
                playerManager.ReduceCombo();
            }

        } else
        {
            bool found = false;
            //check for index 0 each Word in wordList
            foreach (KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                if(eachWord.Value.GetNexLetter() == letter)
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

        if(hasActivedWord && activeWord.WordTypedEnd())
        {
            hasActivedWord = false;       

            if (activeWord.GetWord().Equals(mainWord.GetWord()))
            {
                wordTypingWorkTimer.ReduceWordTimeDelay();
                mainWordlist.Remove(activeID);
                AddMainWordBox();
            }
            else
            {
                mainWordlist.Remove(activeID);
            }

        }
    }

    public void WordOutOffTime()
    {

        if(hasActivedWord == true && activeWord.GetWord().Equals(mainWord.GetWord()))
        {
            hasActivedWord = false;
        }

        mainWordlist[mainID].RemoveWord();
        mainWordlist.Remove(mainID);

        IncreaseBadIdea();
        wordTypingWorkTimer.IncreaseWordTimeDelay();
        AddMainWordBox();
        
    }

    public void OutOffScreen(WorkTypingRandomBox typingGame1RandomBox)
    {
        string id = typingGame1RandomBox.GetID();

        if(activeWord != null)
        {
            if (mainWordlist[id].GetWord().Equals(activeWord.GetWord()) && hasActivedWord == true)
            {
                hasActivedWord = false;
            }
        }

        mainWordlist[id].RemoveWord();
        mainWordlist.Remove(id);
        IncreaseBadIdea();
    }

    public float GetCanvasWidth()
    {
        return canvas.rect.width;
    }

    private void TypingCorrect()
    {
        wordStatistics.WordIsCorrect();
    }

    private void TypingIncorrect()
    {
        wordStatistics.WordIsIncorrect();
    }

    private void IncreaseBadIdea()
    {
        playerManager.IncreaseBadIdea();
    }
}
