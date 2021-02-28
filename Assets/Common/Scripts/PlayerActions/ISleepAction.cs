public interface ISleepAction
{
    void Sleep(int totalSecond);
    int GetCalculateSleepTimeSecond(bool fullTimeSelected);
    int GetMotivationConsumedInSleepAction(int motivationInUse, int totalTime);
}
