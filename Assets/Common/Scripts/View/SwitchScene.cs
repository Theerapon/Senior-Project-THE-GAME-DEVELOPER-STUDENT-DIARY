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
    private const int INST_Display_WorkProject = 9;
    private const int INST_Display_WorkProject_Summary = 10;
    private const int INST_Display_WorkTypingGame = 11;
    private const int INST_Display_AlphaTypingGame = 12;
    private const int INST_Display_BetaTypingGame = 13;
    private const int INST_Display_Place_Clothing_Store = 14;
    private const int INST_Display_Place_Food_Store = 15;
    private const int INST_Display_Place_Material_Store = 16;
    private const int INST_Display_Place_Mystic_Store = 17;
    private const int INST_Display_Place_Park = 18;
    private const int INST_Display_Place_Teacher_Home = 19;
    private const int INST_Display_Place_University = 20;
    #endregion

    #region Animator Parameters
    private const string INST_Triggr_FadeOut = "FadeOut";
    private const string INST_Triggr_FadeIn = "FadeIn";
    private const string INST_Scene = "Scene";
    private const string INST_Active = "Active";
    #endregion

    private bool loadComplete;

    private GameManager gameManager;
    private void Start()
    {
        loadComplete = true;
        gameManager = GameManager.Instance;
        gameManager.onLoadComplete.AddListener(OnloadCompleteHandler);
    }

    private void OnloadCompleteHandler(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        loadComplete = true;
        if (previousGameState != GameManager.GameState.HOME_ACTION || currentGameState == GameManager.GameState.SAVEING)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }

        if(previousGameState == GameManager.GameState.HOME_ACTION && currentGameState == GameManager.GameState.WORK_PROJECT)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }

        if (previousGameState == GameManager.GameState.HOME_ACTION && currentGameState == GameManager.GameState.COURSE)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }

        if (previousGameState == GameManager.GameState.WORK_PROJECT && currentGameState == GameManager.GameState.WORK_PROJECT_MINI_GAME)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        if (previousGameState == GameManager.GameState.MAP && currentGameState == GameManager.GameState.PLACE)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        if (previousGameState == GameManager.GameState.PLACE && currentGameState == GameManager.GameState.MAP)
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
            case INST_Display_WorkProject:
                gameManager.DisplayWorkProject(active);
                break;
            case INST_Display_Course:
                gameManager.DisplayCourse(active);
                break;
            case INST_Display_WorkProject_Summary:
                gameManager.DisplayWorkProjectSummary(active);
                break;
            case INST_Display_WorkTypingGame:
                gameManager.DisplayWorkTypingGame(active);
                break;
            case INST_Display_AlphaTypingGame:
                gameManager.DisplayAlphaTypingGame(active);
                break;
            case INST_Display_BetaTypingGame:
                gameManager.DisplayBetaTypingGame(active);
                break;
            case INST_Display_Place_Clothing_Store:
                gameManager.DisplayPlaceClothing(active);
                break;
            case INST_Display_Place_Food_Store:
                gameManager.DisplayPlaceFood(active);
                break;
            case INST_Display_Place_Material_Store:
                gameManager.DisplayPlaceMaterial(active);
                break;
            case INST_Display_Place_Park:
                gameManager.DisplayPlacePark(active);
                break;
            case INST_Display_Place_Teacher_Home:
                gameManager.DisplayPlaceTeacher(active);
                break;
            case INST_Display_Place_University:
                gameManager.DisplayPlaceUniversity(active);
                break;
            case INST_Display_Place_Mystic_Store:
                gameManager.DisplayPlaceMystic(active);
                break;
        }
        //LoadScene
    }

    #region Switch Scene Command
    public void StartGameWithNewGame()
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Start_New_Game);
            loadComplete = false;
        }
        
    }

    public void StartGameWithContiniueGame()
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Start_Conitiue_Game);
            loadComplete = false;
        }
       
    }

    public void DisplayHomeAction(bool actived, GameManager.GameScene scene)
    {
        //---Not Fade Out---
        gameManager.DisplayHomeAction(actived, scene);

    }


    public void DisplayMenu(bool actived, GameManager.GameScene currentScene, GameManager.GameState toState)
    {
        //---Not Fade Out
        gameManager.DisplayMenu(actived, currentScene, toState);
    }

    public void DispleyMap(bool actived)
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Map, actived);
            loadComplete = false;
        }
        
    }

    public void DisplayCourse(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Course, actived);
            loadComplete = false;
        }
        
    }

    public void DisplayCourseNotification(bool actived)
    {
        //---Not Fade Out---
        gameManager.DisplayCourseNotification(actived);
    }

    public void DisplaySaving(bool actived)
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Saving, actived);
            loadComplete = false;
        }
        
    }

    public void DisplayDiary(bool actived)
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Diary, actived);
            loadComplete = false;
        }
        
    }

    public void DisplayWorkProject(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_WorkProject, actived);
            loadComplete = false;
        }
        
        
    }
    public void DisplayWorkProjectDesign(bool actived)
    {
        //---Not Fand Out---
        gameManager.DisplayWorkProjectDesign(actived);
    }
    public void DisplayWorkProjectSummary(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_WorkProject_Summary, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayWorkTypingGmae(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_WorkTypingGame, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayAlphaTypingGmae(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_AlphaTypingGame, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayBetaTypingGmae(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_BetaTypingGame, actived);
            loadComplete = false;
        }
        
    }
    
    public void DisplayPlaceClothing(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Clothing_Store, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceFood(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Food_Store, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceMaterial(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Material_Store, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayPlacePark(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Park, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceTeacher(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Teacher_Home, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceUniversity(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_University, actived);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceMystic(bool actived)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Mystic_Store, actived);
            loadComplete = false;
        }
        
    }
    #endregion
}
