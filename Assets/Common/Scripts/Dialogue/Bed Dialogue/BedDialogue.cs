using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{
    [SerializeField] private TMP_Text dialogueOne;
    [SerializeField] private TMP_Text dialogueTwo;
    
    private CharacterStats characterStats;
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
        setTextDialogue();
    }

    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                characterStats.ApplySleepFullTimeSelected(true);
                GameManager.Instance.GotoSummaryDiary();
                break;
            case 2:
                characterStats.ApplySleepFullTimeSelected(false);
                GameManager.Instance.GotoSummaryDiary();
                break;
        }
    }

    private void setTextDialogue()
    {
        dialogueOne.text = "Full time to sleep = " +  TimeManager.Instance.GetSecondText(playerAction.GetCalculateSleepTimeSecond(true));
        dialogueTwo.text = "Two third time to sleep = " + TimeManager.Instance.GetSecondText(playerAction.GetCalculateSleepTimeSecond(false));
    }

}
