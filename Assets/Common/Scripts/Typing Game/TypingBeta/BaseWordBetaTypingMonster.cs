using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWordBetaTypingMonster : baseWord
{
    protected BetaWordTypingMonsterBox wordBox;

    public BaseWordBetaTypingMonster(string word, BetaWordTypingMonsterBox spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordBox = spawner;
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
        wordBox.RemoveLetter();
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        wordBox.RemoveWord();
    }

    public void SetID(string id)
    {
        wordBox.Id = id;
    }

    public string GetId()
    {
        return wordBox.Id;
    }

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordBox.UpdatedOrderLayer();
    }

    public override Vector3 GetPositionParent()
    {
        return wordBox.GetShootingPosition();
    }

    public override bool WordTypedEnd()
    {
        bool wordTypeCheck = (typeIndex >= _word.Length);
        if (wordTypeCheck)
        {
            TypedCompleted();
            wordBox.FinishWord(this);
        }
        return wordTypeCheck;
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        wordBox.TypedCompleted();
    }

}
