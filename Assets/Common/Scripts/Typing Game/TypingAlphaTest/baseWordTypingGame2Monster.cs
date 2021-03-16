using UnityEngine;

public class baseWordTypingGame2Monster : baseWord
{
    protected TypingGame2MonsterBox wordDisplayHandler;


    public baseWordTypingGame2Monster(string word, TypingGame2MonsterSpawner spawner, Vector3 originalPosition, Vector3 normalizeDirection, int isRight)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = spawner.SpawnWord(originalPosition, normalizeDirection, isRight);
        wordDisplayHandler.SetWord(word);
        wordDisplayHandler.setMoveDirection(spawner.GetIsRight());
        wordDisplayHandler.SetNormalizeDirection(spawner.GetNormalizeDirection());
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

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordDisplayHandler.UpdatedOrderLayer();
    }
}
