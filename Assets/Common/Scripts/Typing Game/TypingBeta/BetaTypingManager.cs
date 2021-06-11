using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingManager : Manager<BetaTypingManager>
{
    #region Events
    public Events.EventOnCheckedWordUpdate OnCheckedWordUpdate;
    public Events.EventOnBetaTypingGameStateChanged OnTypingGameStateChanged;
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


    public Dictionary<string, baseWord> mainWordlist;
    private bool hasActivedWord;

    private string activeID;
    private baseWord activeWord;
    private baseWord activeBossWord;

    [Header("Player")]
    [SerializeField] private BetaTypingPlayerManager betaTypingPlayerManager;

    [Header("Display Canvas")]
    [SerializeField] private RectTransform canvas;

    [Header("Position Spawner")]
    [SerializeField] private BetaTypingWordBossSpawner betaTypingWordBossSpawner;
    [SerializeField] private BetaTypingWordMonsterSpawner betaTypingWordMonsterSpawner;

    [Header("Position Boss and Player")]
    [SerializeField] private GameObject bossPosition;
    [SerializeField] private GameObject playerPosition;

    [Header("Timer")]
    [SerializeField] private BetaTypingTimer betaTypingTimer;

    public GameObject BossPosition { get => bossPosition; }
    public GameObject PlayerPosition { get => playerPosition; }


    protected override void Awake()
    {
        base.Awake();
        mainWordlist = new Dictionary<string, baseWord>();
        betaTypingPlayerManager.OnBetaTypingPlayerStateChange.AddListener(OnBetaTypingPlayerStateChangeHandler);
    }

    private void OnBetaTypingPlayerStateChangeHandler(BetaTypingPlayerManager.BetaPlayerState state)
    {
        if(state == BetaTypingPlayerManager.BetaPlayerState.Dead)
        {
            UpdateTypingGameState(TypingGameState.PostGame);
        }
    }


    private void Start()
    {
        UpdateTypingGameState(TypingGameState.PreGame);
        //OnCheckedWordUpdate?.Invoke();
    }

    public void AddBossWordBox()
    {
        BaseWordBetaTypingBoss word = new BaseWordBetaTypingBoss(WordGenerater.GetRandomWord(), betaTypingWordBossSpawner.SpawnWord());
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        activeBossWord = word;


    }

    public void AddMonsterWordBox()
    {
        BaseWordBetaTypingMonster word = new BaseWordBetaTypingMonster(WordGenerater.GetRandomWord(), betaTypingWordMonsterSpawner.SpawnWord());
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
    }

    public void AddWordToList(BaseWordBetaTypingMonster word)
    {
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
    }

    internal void TypeLetterManager(char letter)
    {
        if (hasActivedWord)
        {
            //check each letter in word that has actived
            if (activeWord.GetNexLetter() == letter)
            {
                activeWord.TypeLetterEachWord();
            }
            else
            {
                betaTypingPlayerManager.ReduceCombo();
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
                    break;
                    
                }
            }

            if (!found)
            {
                betaTypingPlayerManager.ReduceCombo();
            }
        }

        if (hasActivedWord && activeWord.WordTypedEnd())
        {
            //OnCheckedWordUpdate?.Invoke();
            hasActivedWord = false;

            if (activeWord.GetWord().Equals(activeBossWord.GetWord()))
            {
                betaTypingPlayerManager.Shooting(mainWordlist[activeID].GetPositionParent());
                mainWordlist.Remove(activeID);
                AddBossWordBox();
            }
            else
            {
                betaTypingPlayerManager.Shooting(mainWordlist[activeID].GetPositionParent(), activeWord);
                mainWordlist.Remove(activeID);
            }
        }
    }

    public float GetCanvasWidth()
    {
        return canvas.rect.width;
    }
    public float GetCanvasHeight()
    {
        return canvas.rect.height;
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
        betaTypingTimer.PlaysGame();
    }

    public void RemoveWordFromList(BetaWordTypingMonster word)
    {
        string id = word.Id;

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

}
