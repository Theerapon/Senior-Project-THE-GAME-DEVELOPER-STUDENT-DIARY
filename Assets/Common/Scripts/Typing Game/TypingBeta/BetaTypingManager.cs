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
        Summary
    }
    #endregion
    private TypingGameState typingGameState;


    public Dictionary<string, baseWord> mainWordlist;
    private bool hasActivedWord;

    private string activeID;
    private baseWord activeWord;
    private baseWord activeBossWord;
    private string bossWordID;

    [Header("Statistics")]
    [SerializeField] private WordStatistics wordStatistics;

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

    [Header("Boss")]
    [SerializeField] private BetaTypingGameBossManager bossManager;

    public GameObject BossPosition { get => bossPosition; }
    public GameObject PlayerPosition { get => playerPosition; }


    protected override void Awake()
    {
        base.Awake();
        mainWordlist = new Dictionary<string, baseWord>();
        betaTypingPlayerManager.OnBetaTypingPlayerStateChange.AddListener(OnBetaTypingPlayerStateChangeHandler);
        bossManager.OnBetaTypingBossStateChange.AddListener(OnBetaTypingBossStateChangeHandler);
    }

    private void OnBetaTypingBossStateChangeHandler(BetaTypingGameBossManager.BossState state)
    {
        if(state == BetaTypingGameBossManager.BossState.Weekness)
        {
            KillAllMonster();
        }

        if (state == BetaTypingGameBossManager.BossState.Dead)
        {
            UpdateTypingGameState(TypingGameState.PostGame);
        }
    }


    private void OnBetaTypingPlayerStateChangeHandler(BetaTypingPlayerManager.BetaPlayerState state)
    {
        if(state == BetaTypingPlayerManager.BetaPlayerState.Dead || state == BetaTypingPlayerManager.BetaPlayerState.Timeout)
        {
            UpdateTypingGameState(TypingGameState.PostGame);
        }

    }



    private void Start()
    {
        UpdateTypingGameState(TypingGameState.PreGame);
    }

    public void AddBossWordBox()
    {
        BaseWordBetaTypingBoss word = new BaseWordBetaTypingBoss(WordGenerater.GetRandomWord(), betaTypingWordBossSpawner.SpawnWord());
        bossWordID = word.GetHashCode().ToString();
        mainWordlist.Add(bossWordID, word);
        activeBossWord = word;


    }

    public void AddMonsterWordBox()
    {
        BaseWordBetaTypingMonster word = new BaseWordBetaTypingMonster(WordGenerater.GetRandomWord(), betaTypingWordMonsterSpawner.SpawnWord());
        string id = word.GetHashCode().ToString();
        mainWordlist.Add(id, word);
        word.SetID(id);
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
                TypingCorrect();
            }
            else
            {
                TypingIncorrect();
                betaTypingPlayerManager.ReduceCombo();
            }

        }
        else
        {
            bool found = false;
            //check for index 0 each Word in wordList
            foreach (KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                if(eachWord.Value.GetTypeIndex() < eachWord.Value.GetWord().Length)
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
            }

            if (!found)
            {
                TypingIncorrect();
                betaTypingPlayerManager.ReduceCombo();
            }
        }

        if (hasActivedWord && activeWord.WordTypedEnd())
        {
            hasActivedWord = false;

            if (activeWord.GetWord().Equals(activeBossWord.GetWord()))
            {
                betaTypingPlayerManager.Shooting(mainWordlist[activeID].GetPositionParent());
                mainWordlist.Remove(activeID);
                AddBossWordBox();
            }
            else
            {
                betaTypingPlayerManager.Shooting(mainWordlist[activeID].GetPositionParent(), activeID);
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
        betaTypingTimer.PlaysGame();
    }

    public void RemoveWordFromList(BetaWordTypingMonsterBox word)
    {
        string id = word.Id;

        if (mainWordlist.ContainsKey(id))
        {
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

    public void DestroyWordFromList(BetaWordTypingMonsterBox word)
    {
        string id = word.Id;

        if (mainWordlist.ContainsKey(id))
        {
            if (activeWord != null)
            {
                if (mainWordlist[id].GetWord().Equals(activeWord.GetWord()) && hasActivedWord == true)
                {
                    hasActivedWord = false;
                }
            }

            int wordIncorrect = 0;
            if (mainWordlist[id].GetTypeIndex() + 1 <= mainWordlist[id].GetWord().Length)
            {
                wordIncorrect = (mainWordlist[id].GetWord().Length - (mainWordlist[id].GetTypeIndex() + 1));
            }

            wordStatistics.WordIsIncorrect(wordIncorrect);

            mainWordlist[id].RemoveWord();
            mainWordlist.Remove(id);
        }


    }

    private void TypingCorrect()
    {
        wordStatistics.WordIsCorrect();
    }

    private void TypingIncorrect()
    {
        wordStatistics.WordIsIncorrect();
    }

    private void KillAllMonster()
    {
        hasActivedWord = false;
        if (mainWordlist.Count > 0)
        {
            foreach (KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                string id = eachWord.Key;
                if (!id.Equals(bossWordID))
                {
                    betaTypingPlayerManager.Shooting(mainWordlist[id].GetPositionParent(), id);
                }
            }
        }
    }

    public void UseUltimateSKill(int amount)
    {
        KillMonsters(amount);
        betaTypingTimer.ReduceGameTime(5);
    }

    private void KillMonsters(int amount)
    {

        if (mainWordlist.Count > amount)
        {
            int i = 0;
            foreach (KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                string id = eachWord.Key;
                if (!id.Equals(bossWordID) && i < amount)
                {
                    betaTypingPlayerManager.Shooting(mainWordlist[id].GetPositionParent(), id);
                    i++;
                }
            }
        }
        else
        {
            foreach (KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                string id = eachWord.Key;
                if (!id.Equals(bossWordID))
                {
                    betaTypingPlayerManager.Shooting(mainWordlist[id].GetPositionParent(), id);
                }
            }
        }
    }
}
