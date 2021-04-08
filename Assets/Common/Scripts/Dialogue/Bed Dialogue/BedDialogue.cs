using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{
    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                //GameManager.Instance.GotoSummaryDiary();
                break;
            case 2:
                //GameManager.Instance.GotoSummaryDiary();
                break;
        }
    }

}
