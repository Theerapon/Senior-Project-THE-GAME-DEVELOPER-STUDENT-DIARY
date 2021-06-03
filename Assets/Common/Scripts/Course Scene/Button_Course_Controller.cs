using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Course_Controller : MonoBehaviour
{
    [Header("Course Display Controller")]
    [SerializeField] private Course_Display_Controller course_display_controller;

    [Header("Button")]
    [SerializeField] private Button[] buttons;

    [Header("Line")]
    [SerializeField] private Image[] lines;

    private void Start()
    {
        OnButtonClicked(buttons[0]);
    }

    #region Button Menu
    public void OpenAllCourseMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        course_display_controller.ActivedAllCourse();
    }

    public void OpenMyCourseMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        course_display_controller.ActivedMyCourse();
    }
    #endregion

    public void SetAllButtonsInteractable(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            if (button == clickedButton)
            {
                clickedButton.interactable = false;
            }
            else
            {
                button.interactable = true;
            }

        }

        for (int i = 0; i < buttons.Length; i++)
        {
            if(buttons[i].interactable == false)
            {
                lines[i].gameObject.SetActive(true);
            }
            else
            {
                lines[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == -1)
            return;

        SetAllButtonsInteractable(clickedButton);
    }
}

