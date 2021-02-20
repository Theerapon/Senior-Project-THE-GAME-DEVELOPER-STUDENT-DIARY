using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{
    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                GameManager.Instance.SummaryDiary();
                break;
            case 2:
                GameManager.Instance.SummaryDiary();
                break;
        }
    }

}
