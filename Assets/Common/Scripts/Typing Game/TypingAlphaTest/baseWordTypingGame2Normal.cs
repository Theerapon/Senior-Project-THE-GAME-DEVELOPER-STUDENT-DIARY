using UnityEngine;

public class baseWordTypingGame2Normal : baseWord
{
    protected TypingGame2Box wordDisplayHandler;
    

    public baseWordTypingGame2Normal(string word, TypingGame2Spawner spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = spawner.SpawnWord();
        wordDisplayHandler.SetWord(word);
        wordDisplayHandler.setMoveDirection(spawner.GetIsRight());
        wordDisplayHandler.SetNormalizeDirection(spawner.GetGoldPosition());
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
        wordDisplayHandler.SetID(id);
    }

    public override void CreatedMonsterBox()
    {
        base.CreatedMonsterBox();
        if (Random.Range(0, 50) < 10)
        {
            wordDisplayHandler.CreatedMonsterBox();
        }
    }

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordDisplayHandler.UpdatedOrderLayer();
    }
}
