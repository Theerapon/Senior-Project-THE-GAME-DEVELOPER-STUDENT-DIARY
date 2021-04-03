using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{
    [SerializeField] private TMP_Text dialogueOne;
    [SerializeField] private TMP_Text dialogueTwo;
    
    private Characters_Handler chracter_handler;
    private GameObject found_Player;
    private PlayerAction playerAction;

    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
        setTextDialogue();
    }

    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                GameManager.Instance.GotoSummaryDiary();
                break;
            case 2:
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
