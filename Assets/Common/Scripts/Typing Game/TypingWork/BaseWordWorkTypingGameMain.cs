[System.Serializable]
public class BaseWordWorkTypingGameMain : baseWord
{
    protected WorkTypingMainBox wordDisplayHandler;

    public BaseWordWorkTypingGameMain(string word, WorkTypingMainBox display)
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

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordDisplayHandler.UpdatedOrderLayer();
    }


}
