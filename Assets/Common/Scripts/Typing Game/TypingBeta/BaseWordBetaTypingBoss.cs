using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWordBetaTypingBoss : baseWord
{
    protected BetaWordBossBox wordBox;

    public BaseWordBetaTypingBoss(string word, BetaWordBossBox spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordBox = spawner;
        spawner.SetWord(word);
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

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordBox.UpdatedOrderLayer();
    }

    public override Vector3 GetPositionParent()
    {
        return wordBox.GetShootingPosition();
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        wordBox.TypedCompleted();
    }


}
