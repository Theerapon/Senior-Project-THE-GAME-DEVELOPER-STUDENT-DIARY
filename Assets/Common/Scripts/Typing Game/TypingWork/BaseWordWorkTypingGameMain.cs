[System.Serializable]
public class BaseWordWorkTypingGameMain : baseWord
{
    protected WorkTypingMainBox wordBox;

    public BaseWordWorkTypingGameMain(string word, WorkTypingMainBox display)
    {
        this._word = word;
        typeIndex = 0;

        wordBox = display;
        display.SetWord(word);
    }

    public override void TypeLetterEachWord()
    {
        base.TypeLetterEachWord();
        wordBox.RemoveLetter();
        SlowTime();
    }

    private void SlowTime()
    {
        wordBox.SlowTime();
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

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        wordBox.TypedCompleted();
    }


}
