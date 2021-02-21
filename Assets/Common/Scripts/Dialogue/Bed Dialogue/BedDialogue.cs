using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{
    [SerializeField] private TMP_Text dialogueOne;
    [SerializeField] private TMP_Text dialogueTwo;
    private CharacterStats characterStats;
    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                characterStats.ApplySleepFullTimeSelected(true);
                GameManager.Instance.SummaryDiary();
                break;
            case 2:
                characterStats.ApplySleepFullTimeSelected(false);
                GameManager.Instance.SummaryDiary();
                break;
        }
    }

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        setTextDialogue();
    }

    private void setTextDialogue()
    {
        dialogueOne.text = characterStats.GetFullTimeSleepText();
        dialogueTwo.text = characterStats.GetTwoThirdSleepText();
    }

}
