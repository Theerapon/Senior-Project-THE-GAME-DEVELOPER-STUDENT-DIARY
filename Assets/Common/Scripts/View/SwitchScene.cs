using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : Manager<SwitchScene>
{

    #region INST
    private const int INST_Start_New_Game = 0;
    private const int INST_Start_Conitiue_Game = 1;
    private const int INST_Display_HomeAction = 2;
    private const int INST_Display_Menu = 3;
    private const int INST_Display_Map = 4;
    private const int INST_Display_Course = 5;
    private const int INST_Display_Course_Notification = 6;
    private const int INST_Display_Saving = 7;
    private const int INST_Display_Diary = 8;
    #endregion

    #region Animator Parameters
    private const string INST_Triggr_FadeOut = "FadeOut";
    private const string INST_Triggr_FadeIn = "FadeIn";
    private const string INST_Scene = "Scene";
    private const string INST_Active = "Active";
    #endregion

    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.onLoadComplete.AddListener(OnloadCompleteHandler);
    }

    private void OnloadCompleteHandler(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        if(previousGameState != GameManager.GameState.HOME_ACTION || currentGameState == GameManager.GameState.SAVEING)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
    }

    [SerializeField] private Animator animator;

    public void FadeToLevel(int number, bool active)
    {
        animator.SetTrigger(INST_Triggr_FadeOut);
        animator.SetInteger(INST_Scene, number);
        animator.SetBool(INST_Active, active);
    }
    public void FadeToLevel(int number)
    {
        animator.SetTrigger(INST_Triggr_FadeOut);
        animator.SetInteger(INST_Scene, number);
    }

    public void OnFadeOutComplete()
    {
        int scene = animator.GetInteger(INST_Scene);
        bool active = animator.GetBool(INST_Active);

        switch (scene)
        {
            case INST_Start_New_Game:
                gameManager.StartGameWithNewGame();
                break;
            case INST_Start_Conitiue_Game:
                gameManager.StartGameWithContiniueGame();
                break;
            case INST_Display_Map:
                gameManager.DispleyMap(active);
                break;
            case INST_Display_Saving:
                gameManager.DisplaySaving(active);
                break;
            case INST_Display_Diary:
                gameManager.DisplayDiary(active);
                break;
        }
        //LoadScene
    }

    #region Switch Scene Command
    public void StartGameWithNewGame()
    {
        //---Fade Out---
        FadeToLevel(INST_Start_New_Game);
    }

    public void StartGameWithContiniueGame()
    {
        //---Fade Out---
        FadeToLevel(INST_Start_Conitiue_Game);
    }

    public void DisplayHomeAction(bool actived, GameManager.GameScene scene)
    {
        //---Not Fade Out---
        GameManager.Instance.DisplayHomeAction(actived, scene);
    }


    public void DisplayMenu(bool actived, GameManager.GameScene currentScene, GameManager.GameState toState)
    {
        //---Not Fade Out
        GameManager.Instance.DisplayMenu(actived, currentScene, toState);
    }

    public void DispleyMap(bool actived)
    {
        //---Fade Out---
        FadeToLevel(INST_Display_Map, actived);
    }

    public void DisplayCourse(bool actived)
    {
        //---Not Fand Out---
        GameManager.Instance.DisplayCourse(actived);
    }

    public void DisplayCourseNotification(bool actived)
    {
        //---Not Fade Out---
        GameManager.Instance.DisplayCourseNotification(actived);
    }

    public void DisplaySaving(bool actived)
    {
        //---Fade Out---
        FadeToLevel(INST_Display_Saving, actived);
    }

    public void DisplayDiary(bool actived)
    {
        FadeToLevel(INST_Display_Diary, actived);
    }
    #endregion
}
