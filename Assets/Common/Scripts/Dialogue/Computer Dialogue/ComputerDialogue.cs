using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerDialogue : MonoBehaviour, IDialogue
{
    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                GameManager.Instance.DisplayCourse(true);
                break;
            case 2:
                //GameManager.Instance.GotoWorkProject();
                break;
        }
    }

}
