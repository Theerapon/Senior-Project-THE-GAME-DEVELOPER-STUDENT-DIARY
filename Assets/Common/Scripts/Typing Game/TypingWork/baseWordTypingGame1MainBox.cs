[System.Serializable]
public class baseWordTypingGame1MainBox : baseWord
{
    protected TypingGame1MainBox wordDisplayHandler;

    public baseWordTypingGame1MainBox(string word, TypingGame1MainBox display)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = display;
        display.SetWord(word);
    }

    public override void TypeLetterEachWord()
    {
        base.TypeLetterEachWord();
        wordDisplayHandler.RemoveLetter();
        SlowTime();
    }

    private void SlowTime()
    {
        wordDisplayHandler.SlowTime();
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        wordDisplayHandler.RemoveWord();
    }

    
}
