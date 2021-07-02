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
    private const int INST_Display_RecieveTrasure = 21;
    private const int INST_Display_StachInventory = 22;
    private const int INST_Display_CourseSummary = 23;
    private const int INST_Display_Sleeplate = 24;
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
        else if (previousGameState == GameManager.GameState.HOME_ACTION && currentGameState == GameManager.GameState.WORK_PROJECT)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if ((previousGameState == GameManager.GameState.HOME_ACTION || previousGameState == GameManager.GameState.COURSE_SUMMARY) && currentGameState == GameManager.GameState.COURSE)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.WORK_PROJECT && currentGameState == GameManager.GameState.WORK_PROJECT_MINI_GAME)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.MAP && currentGameState == GameManager.GameState.PLACE)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.PLACE && currentGameState == GameManager.GameState.MAP)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.OPENINGTREASURE && currentGameState == GameManager.GameState.RECEIVE_ITEM)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.RECEIVE_ITEM && currentGameState == GameManager.GameState.STACH)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.COURSE_NOTIFICATION && currentGameState == GameManager.GameState.COURSE_SUMMARY)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (currentGameState == GameManager.GameState.SLEEPLATE)
        {
            animator.SetTrigger(INST_Triggr_FadeIn);
        }
        else if (previousGameState == GameManager.GameState.TRANSPORTING && (currentGameState == GameManager.GameState.HOME || currentGameState == GameManager.GameState.MAP))
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
            case INST_Display_RecieveTrasure:
                gameManager.DisplayReceiveTreasure(active);
                break;
            case INST_Display_StachInventory:
                gameManager.DisplayStachInventory(active);
                break;
            case INST_Display_CourseSummary:
                gameManager.DisplayCourseSummary(active);
                break;
            case INST_Display_Sleeplate:
                gameManager.DisplaySleeplate(active);
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

    public void DispleyMap(bool active)
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Map, active);
            loadComplete = false;
        }
        
    }

    public void DisplayCourse(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Course, active);
            loadComplete = false;
        }
        
    }
    public void DisplaySleeplate(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Sleeplate, active);
            loadComplete = false;
        }

    }

    public void DisplayCourseNotification(bool active)
    {
        //---Not Fade Out---
        gameManager.DisplayCourseNotification(active);
    }

    public void DisplaySaving(bool active)
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Saving, active);
            loadComplete = false;
        }
        
    }

    public void DisplayDiary(bool active)
    {
        //---Fade Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Diary, active);
            loadComplete = false;
        }
        
    }

    public void DisplayWorkProject(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_WorkProject, active);
            loadComplete = false;
        }
        
        
    }
    public void DisplayWorkProjectDesign(bool active)
    {
        //---Not Fand Out---
        gameManager.DisplayWorkProjectDesign(active);
    }
    public void DisplayWorkProjectSummary(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_WorkProject_Summary, active);
            loadComplete = false;
        }
        
    }
    public void DisplayWorkTypingGmae(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_WorkTypingGame, active);
            loadComplete = false;
        }
        
    }
    public void DisplayAlphaTypingGmae(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_AlphaTypingGame, active);
            loadComplete = false;
        }
        
    }
    public void DisplayBetaTypingGmae(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_BetaTypingGame, active);
            loadComplete = false;
        }
        
    }
    
    public void DisplayPlaceClothing(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Clothing_Store, active);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceFood(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Food_Store, active);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceMaterial(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Material_Store, active);
            loadComplete = false;
        }
        
    }
    public void DisplayPlacePark(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Park, active);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceTeacher(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Teacher_Home, active);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceUniversity(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_University, active);
            loadComplete = false;
        }
        
    }
    public void DisplayPlaceMystic(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_Place_Mystic_Store, active);
            loadComplete = false;
        }
        
    }
    public void OpeningTreasure()
    {
        gameManager.OpeningTreasure();
    }
    public void DisplayReceiveTreasure(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_RecieveTrasure, active);
            loadComplete = false;
        }
    }
    public void DisplayStachInventory(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_StachInventory, active);
            loadComplete = false;
        }
    }
    public void DisplayCourseSummary(bool active)
    {
        //---Fand Out---
        if (loadComplete)
        {
            FadeToLevel(INST_Display_CourseSummary, active);
            loadComplete = false;
        }
    }
    #endregion
}
