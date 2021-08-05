using UnityEngine;

public class baseWordAlphaTypingMonster : baseWord
{
    protected AlphaTypingMonsterBox wordBox;


    public baseWordAlphaTypingMonster(string word, AlphaTypingMonsterSpawner spawner, Vector3 originalPosition, Vector3 normalizeDirection, int isRight)
    {
        this._word = word;
        typeIndex = 0;

        wordBox = spawner.SpawnWord(originalPosition, normalizeDirection, isRight);
        wordBox.SetWord(word);
        wordBox.setMoveDirection(spawner.GetIsRight());
        wordBox.SetNormalizeDirection(spawner.GetNormalizeDirection());
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
        wordBox.SetID(id);
    }

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordBox.UpdatedOrderLayer();
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        wordBox.TypedCompleted();
    }
}
