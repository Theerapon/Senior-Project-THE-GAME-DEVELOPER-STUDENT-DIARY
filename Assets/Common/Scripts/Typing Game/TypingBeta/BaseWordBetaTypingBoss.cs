using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWordBetaTypingBoss : baseWord
{
    protected BetaWordBossBox wordDisplayHandler;

    public BaseWordBetaTypingBoss(string word, BetaWordBossBox spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = spawner;
        spawner.SetWord(word);
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

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordDisplayHandler.UpdatedOrderLayer();
    }

    public override Vector3 GetPositionParent()
    {
        return wordDisplayHandler.GetShootingPosition();
    }


}
