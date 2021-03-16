using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingGame1Manager : Manager<TypingGame1Manager>
{
    #region Events
    public Events.EventOnCheckedWordUpdate OnCheckedWordUpdate;
    #endregion

    private int score;
    private int wordCorrect;
    private int wordIncorrect;
    private int comboCount;

    public Dictionary<string, baseWord> mainWordlist;

    private bool hasActivedWord;
    private string activeID;
    private baseWord activeWord;
    private string mainID;
    private baseWord mainWord;

    [SerializeField] private RectTransform canvas;

    [SerializeField] private TypingGame1MainSpawner wordMainSpawner;
    [SerializeField] private TypingGame1RandomSpawner wordRandomSpawner;

    private TypingGame1Timer wordTypingWorkTimer;

    protected override void Awake()
    {
        base.Awake();
        mainWordlist = new Dictionary<string, baseWord>();
    }
    private void Start()
    {
        wordTypingWorkTimer = FindObjectOfType<TypingGame1Timer>();
    }

    public void AddMainWordBox()
    {
        baseWordTypingGame1Main word = new baseWordTypingGame1Main(WordGenerater.GetRandomWord(), wordMainSpawner.SpawnWord());
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        mainWord = word;
        mainID = word.GetHashCode().ToString();


    }

    public void AddRandomWordBox()
    {
        baseWordTypingGame1Random word = new baseWordTypingGame1Random(WordGenerater.GetRandomWord(), wordRandomSpawner);
        mainWordlist.Add(word.GetHashCode().ToString(), word);
        word.SetID(word.GetHashCode().ToString());
    }

    public void TypeLetterManager(char letter)
    {
        if (hasActivedWord)
        {
            //check each letter in word that has actived
            if(activeWord.GetNexLetter() == letter)
            {
                activeWord.TypeLetterEachWord();
            }
            else
            {
                wordIncorrect++;
                OnCheckedWordUpdate?.Invoke();
            }

        } else
        {
            //check for index 0 each Word in wordList
            foreach(KeyValuePair<string, baseWord> eachWord in mainWordlist)
            {
                if(eachWord.Value.GetNexLetter() == letter)
                {
                    activeID = eachWord.Key;
                    activeWord = eachWord.Value;
                    hasActivedWord = true;
                    eachWord.Value.TypeLetterEachWord();
                    eachWord.Value.UpdatedOrderLayer();
                    break;
                }
                else
                {
                    wordIncorrect++;
                    OnCheckedWordUpdate?.Invoke();
                }
            }
        }

        if(hasActivedWord && activeWord.WordTypedEnd())
        {
            wordCorrect++;
            OnCheckedWordUpdate?.Invoke();
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
        wordIncorrect++;
        OnCheckedWordUpdate?.Invoke();

        if(hasActivedWord == true && activeWord.GetWord().Equals(mainWord.GetWord()))
        {
            hasActivedWord = false;
        }

        mainWordlist[mainID].RemoveWord();
        mainWordlist.Remove(mainID);

        wordTypingWorkTimer.IncreaseWordTimeDelay();
        AddMainWordBox();
        
    }

    public int GetScore()
    {
        return score;
    }
    public int GetWordCorrent()
    {
        return wordCorrect; 
    }
    public int GetWordIncorrect()
    {
        return wordIncorrect;
    }
    public int GetComboCount()
    {
        return comboCount;
    }

    public void OutOffScreen(TypingGame1RandomBox typingGame1RandomBox)
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
    }

    public float GetCanvasWidth()
    {
        return canvas.rect.width;
    }
}
