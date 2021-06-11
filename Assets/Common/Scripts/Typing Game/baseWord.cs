using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseWord
{
    protected string _word;
    protected int typeIndex;

    public virtual string GetWord()
    {
        return _word;
    }


    public virtual char GetNexLetter()
    {
        return _word[typeIndex];
    }

    public virtual void TypeLetterEachWord()
    {
        typeIndex++;
    }

    public virtual bool WordTypedEnd()
    {
        bool wordTypeCheck = (typeIndex >= _word.Length);
        if (wordTypeCheck)
        {
            RemoveWord();
        }
        return wordTypeCheck;
    }

    public virtual void RemoveWord()
    {

    }

    public virtual void CreatedMonsterBox()
    {

    }

    public virtual void UpdatedOrderLayer()
    {

    }

    public virtual Vector3 GetPositionParent()
    {
        return Vector3.zero;
    }
}
