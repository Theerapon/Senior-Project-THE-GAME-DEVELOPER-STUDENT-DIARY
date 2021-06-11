using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWordBetaTypingMonster : baseWord
{
    protected BetaWordTypingMonster wordDisplayHandler;

    public BaseWordBetaTypingMonster(string word, BetaWordTypingMonster spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = spawner;
        spawner.SetWord(word);
    }

    public void ResetWord(string word)
    {
        this._word = word;
        typeIndex = 0;
    }

    public override void TypeLetterEachWord()
    {
        base.TypeLetterEachWord();
        wordDisplayHandler.RemoveLetter();
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        wordDisplayHandler.RemoveWord();
    }

    public void SetID(string id)
    {
        wordDisplayHandler.Id = id;
    }

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordDisplayHandler.UpdatedOrderLayer();
    }

    public override Vector3 GetPositionParent()
    {
        return wordDisplayHandler.GetShootingPosition();
    }

    public override bool WordTypedEnd()
    {
        bool wordTypeCheck = (typeIndex >= _word.Length);
        if (wordTypeCheck)
        {
            wordDisplayHandler.FinishWord(this);
        }
        return wordTypeCheck;
    }

}
