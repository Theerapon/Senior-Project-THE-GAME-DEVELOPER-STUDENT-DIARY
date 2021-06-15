using UnityEngine;

public class baseWordAlphaTypingNormal : baseWord
{
    protected AlphaTypingBox wordBox;
    

    public baseWordAlphaTypingNormal(string word, AlphaTypingSpawner spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordBox = spawner.SpawnWord();
        wordBox.SetWord(word);
        wordBox.setMoveDirection(spawner.GetIsRight());
        wordBox.SetNormalizeDirection(spawner.GetGoldPosition());
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

    public override void CreatedMonsterBox()
    {
        base.CreatedMonsterBox();
        if (Random.Range(0, 50) < 10)
        {
            wordBox.CreatedMonsterBox();
        }
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
