using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    private string _word;
    private int typeIndex;

    private WordDisplay wordDisplayHandler;
    
    public Word(string word, WordDisplay display)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = display;
        display.SetWord(word);
    }

    public string GetWord()
    {
        return _word;
    }


    public char GetNexLetter()
    {
        return _word[typeIndex];
    }

    public void TypeLetterEachWord()
    {
        typeIndex++;
        wordDisplayHandler.RemoveLetter();
    }

    public bool WordTypedEnd()
    {
        bool wordTypeCheck = (typeIndex >= _word.Length);
        if (wordTypeCheck)
        {
            wordDisplayHandler.RemoveWord();
        }
        return wordTypeCheck;
    }
}
