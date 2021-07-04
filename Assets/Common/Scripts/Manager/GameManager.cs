using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    #region Events Action and AsyncOperation 
    public Events.EventGameState OnGameStateChanged;
    public Events.EventOnLoadComplete onLoadComplete;
    public Events.EventOnHomeDisplay onHomeDisplay;
    private static Action onLoaderCallback;

    private static AsyncOperation ao;
    #endregion

    private class LoadingMonoBehaviour : MonoBehaviour { }

    #region Enums
    public enum GameScene
    {
        Boot,
        Home,
        Summary,
        COM_Course,
        COM_Course_Summary,
        COM_WorkProject,
        COM_WorkProject_Design,
        COM_WorkProject_Summary,
        HUD_Info,
        Menu_Bag,
        Menu_Characters,
        Menu_Ideas,
        Menu_Exit,
        Home_Storage,
        Home_BED,
        Home_COMPUTER,
        HOME_Calendar,
        Map,
        Saving,
        Diary,
        PreparingData,
        TypingAlphaTest,
        TypingBetaTest,
        TypingWork,
        Place_Clothing_Store,
        Place_Food_Store,
        Place_Material_Store,
        Place_Mystic_Store,
        Place_Park,
        Place_Teacher_Home,
        Place_University,
        ReceiveItems,
        StachInventory,
        SleepLate,
        Transport,
        HUD_Dialouge,

    }


    public static GameScene _currentGameScene;

    public GameScene CurrentGameScene
    {
        get { return _currentGameScene; }
        set { _currentGameScene = value; }
    }


    public enum GameState
    {
        PREGAME,
        PREPARINGDATA,
        FIRST_SCENE,
        HOME,
        HOME_ACTION,
        COURSE,
        COURSE_NOTIFICATION,
        COURSE_SUMMARY,
        SAVEING,
        Diary,
        CARD,
        HOME_DIALOUGE,
        ENDING,
        ENDING_DIALOUGE,
        ENDING_CREDIT,
        MAP,
        OPENINGTREASURE,
        RECEIVE_ITEM,
        STACH,
        PLACE,
        DIALOUGE,
        PROJECT_DISCUSS,
        PROJECT_DISCUSS_DIALOUGE,
        PROJECT_DISCUSS_ANALYZE,
        CLASS,
        GIFT,
        MENU,
        WORK_PROJECT,
        WORK_PROJECT_DESIGN,
        WORK_PROJECT_MINI_GAME,
        WORK_PROJECT_ANIMATION,
        WORK_PROJECT_DIALOUGE,
        WORK_PROJECT_SUMMARY,
        TRANSPORTING,
        SLEEPLATE,
        ONTHEWAY,
        CALENDAR,
    }

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set { _currentGameState = value; }
    }

    GameState _currentGameState = GameState.PREGAME;
    GameState _previousGameState;
    #endregion

    #region Identification
    public GameObject[] SystemPrefabs;
    List<GameObject> _instancedSystemPrefabs;
    #endregion


    protected override void Awake()
    {
        base.Awake();
        _instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();
    }

    void UpdateState(GameState state)
    {
        _previousGameState = _currentGameState;
        _currentGameState = state;
 
        OnGameStateChanged?.Invoke(_currentGameState, _previousGameState);
    }
    void UpdateScene(GameScene scene)
    {
        #region Boot
        if (scene == GameScene.Boot)
        {
            UpdateState(GameState.PREGAME);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        if(scene == GameScene.PreparingData)
        {
            UpdateState(GameState.PREPARINGDATA);
        }

        #region Home
        if (scene == GameScene.Home && !SceneManager.GetSceneByName(GameScene.HUD_Info.ToString()).isLoaded)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.HUD_Info);
            UpdateState(GameState.HOME);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            onHomeDisplay?.Invoke(true);
        } else if (scene == GameScene.Home)
        {
            UpdateState(GameState.HOME);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            onHomeDisplay?.Invoke(true);
        }
        #endregion

        #region Menu
        if (scene == GameScene.Menu_Bag || scene == GameScene.Menu_Characters || scene == GameScene.Menu_Ideas || scene == GameScene.Menu_Exit)
        {
            UpdateState(GameState.MENU);
        }
        #endregion

        #region Home Action
        if (scene == GameScene.Home_Storage || scene == GameScene.Home_COMPUTER || scene == GameScene.Home_BED)
        {
            UpdateState(GameState.HOME_ACTION);
        }
        if(scene == GameScene.HOME_Calendar)
        {
            UpdateState(GameState.CALENDAR);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region Dialouge
        if (scene == GameScene.HUD_Dialouge)
        {
            UpdateState(GameState.DIALOUGE);
        }
        #endregion

        #region Map
        if (scene == GameScene.Map)
        {
            UpdateState(GameState.MAP);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            onHomeDisplay?.Invoke(false);
        }
        #endregion

        #region Sleep
        if(scene == GameScene.SleepLate)
        {
            UpdateState(GameState.SLEEPLATE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region Course
        if (scene == GameScene.COM_Course)
        {
            UpdateState(GameState.COURSE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if(scene == GameScene.COM_Course_Summary)
        {
            UpdateState(GameState.COURSE_SUMMARY);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region Saving
        if(scene == GameScene.Saving)
        {
            UpdateState(GameState.SAVEING);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region Diary
        if(scene == GameScene.Diary)
        {
            UpdateState(GameState.Diary);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region Recieve Item
        if (scene == GameScene.ReceiveItems)
        {
            UpdateState(GameState.RECEIVE_ITEM);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if(scene == GameScene.StachInventory)
        {
            UpdateState(GameState.STACH);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region WorkProject
        if (scene == GameScene.COM_WorkProject)
        {
            UpdateState(GameState.WORK_PROJECT);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }

        if(scene == GameScene.COM_WorkProject_Design)
        {
            UpdateState(GameState.WORK_PROJECT_DESIGN);
        }

        if(scene == GameScene.COM_WorkProject_Summary)
        {
            UpdateState(GameState.WORK_PROJECT_SUMMARY);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region mini Game
        if (scene == GameScene.TypingWork)
        {
            UpdateState(GameState.WORK_PROJECT_MINI_GAME);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.TypingAlphaTest)
        {
            UpdateState(GameState.WORK_PROJECT_MINI_GAME);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.TypingBetaTest)
        {
            UpdateState(GameState.WORK_PROJECT_MINI_GAME);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion

        #region Place
        if (scene == GameScene.Place_Clothing_Store)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.Place_Food_Store)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.Place_Material_Store)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.Place_Mystic_Store)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.Place_Park)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.Place_Teacher_Home)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        if (scene == GameScene.Place_University)
        {
            UpdateState(GameState.PLACE);
            onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
        }
        #endregion


    }

    

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        UpdateScene(_currentGameScene);
    }

    #region Loading
    public bool LoadLevelSceneWithOutLoadingScene(GameScene sceneName)
    {
        ao = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + sceneName.ToString());
            return false;
        }
        _currentGameScene = sceneName;
        ao.completed += OnLoadOperationComplete;
        return true;
    }

    IEnumerator LoadingScene(GameScene sceneName)
    {
        yield return null;

        ao = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + sceneName.ToString());
            yield return null;
        }

        while (!ao.isDone)
        {
            
            yield return null;
        }


        _currentGameScene = sceneName;
        ao.completed += OnLoadOperationComplete;


    }

    public bool UnLoadLevel(GameScene sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName.ToString());
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + sceneName.ToString());
            return false;
        }
        return true;
    }

    public static float GetLoadingProgress()
    {
        if (ao != null)
        {
            return ao.progress;
        }
        else if(ao != null &&  ao.progress > 1f)
        {
            return 1f;
        } else
        {
            return 0f;
        }
    }

    public static void LoaderCallback()
    {
        // Triggered after the first Update which lets the screen refresh
        // Execute the loader callback action which will load the target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

#endregion

    protected void OnDestroy()
    {
        if (_instancedSystemPrefabs == null)
            return;

        for (int i = 0; i < _instancedSystemPrefabs.Count; ++i)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }


    #region Scenes
    public void StartGameWithNewGame()
    {
        if (!SceneManager.GetSceneByName(GameScene.PreparingData.ToString()).isLoaded)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.PreparingData);
        }
        
    }
    public void StartGameWithContiniueGame()
    {
        if (!SceneManager.GetSceneByName(GameScene.PreparingData.ToString()).isLoaded)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.PreparingData);
        }
    }
    public void DisplayHome()
    {
        if (!SceneManager.GetSceneByName(GameScene.Home.ToString()).isLoaded)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.Home);
        }

    }
    public void DisplayHomeAction(bool actived, GameScene scene)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(scene.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(scene);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(scene.ToString()).isLoaded)
            {
                UnLoadLevel(scene);
                UpdateScene(GameScene.Home);
            }

        }
    }

    private GameManager.GameScene present_menu;
    private bool menu_hasDisplayed = false;
    public void DisplayMenu(bool actived, GameScene currentScene, GameState toState)
    {

        if (actived)
        {
            if (present_menu == currentScene && menu_hasDisplayed == true)
                return;

            UnLoadMenuSceneHasActived();
            if (LoadLevelSceneWithOutLoadingScene(currentScene))
            {
                present_menu = currentScene;
                menu_hasDisplayed = true;
            }
        }
        else
        {
            if (SceneManager.GetSceneByName(currentScene.ToString()).isLoaded)
            {
                UnLoadLevel(currentScene);
                UpdateState(toState);
                menu_hasDisplayed = false;
            }
            
        }
    }
    public void DispleyMap(bool actived)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(GameScene.Map.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Map);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Map.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Map);
                UpdateScene(GameScene.Home);
            }
            
        }
    }
    public void DisplayCourse(bool actived)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(GameScene.COM_Course.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Home_COMPUTER);
                LoadLevelSceneWithOutLoadingScene(GameScene.COM_Course);
            }

        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.COM_Course.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.COM_Course);
                UpdateScene(GameScene.Home);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayCourseNotification(bool actived)
    {
        if (actived)
        {
            UpdateState(GameState.COURSE_NOTIFICATION);
        }
        else
        {
            UpdateState(GameState.COURSE);
        }
    }
    public void DisplaySaving(bool actived)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(GameScene.Saving.ToString()).isLoaded)
            {
                if (SceneManager.GetSceneByName(GameScene.Home_BED.ToString()).isLoaded)
                {
                    UnLoadLevel(GameScene.Home_BED);
                }
                else if (SceneManager.GetSceneByName(GameScene.SleepLate.ToString()).isLoaded)
                {
                    UnLoadLevel(GameScene.SleepLate);
                }

                LoadLevelSceneWithOutLoadingScene(GameScene.Saving);
            }
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Saving.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Saving);
                UpdateScene(GameScene.Home);
            }
            
        }
    }
    public void DisplaySleeplate(bool actived)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(GameScene.SleepLate.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.SleepLate);
            }
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.SleepLate.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.SleepLate);
                UpdateScene(GameScene.Home);
            }

        }
    }
    public void DisplayDiary(bool actived)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(GameScene.Diary.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Saving);
                LoadLevelSceneWithOutLoadingScene(GameScene.Diary);
            }
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Diary.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Diary);

                if (SceneManager.GetSceneByName(GameScene.Map.ToString()).isLoaded)
                {
                    UpdateScene(GameScene.Map);
                }
                else
                {
                    UpdateScene(GameScene.Home);
                }
                
            }
            
        }
    }
    public void DisplayCalendar(bool actived)
    {
        if (actived)
        {
            if (!SceneManager.GetSceneByName(GameScene.HOME_Calendar.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.HOME_Calendar);
            }
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.HOME_Calendar.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.HOME_Calendar);
                UpdateScene(GameScene.Home);
            }

        }
    }
    public void DisplayWorkProject(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.COM_WorkProject.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Home_COMPUTER);
                LoadLevelSceneWithOutLoadingScene(GameScene.COM_WorkProject);
            }

            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.COM_WorkProject.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.COM_WorkProject);
                UpdateState(GameState.HOME);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayWorkProjectDesign(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.COM_WorkProject_Design.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.COM_WorkProject_Design);

            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.COM_WorkProject_Design.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.COM_WorkProject_Design);
                UpdateState(GameState.WORK_PROJECT);
            }

            
        }
    }
    public void DisplayWorkProjectSummary(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.COM_WorkProject_Summary.ToString()).isLoaded)
            {
                UnLoadLevel(CurrentGameScene);
                LoadLevelSceneWithOutLoadingScene(GameScene.COM_WorkProject_Summary);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.COM_WorkProject_Summary.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.COM_WorkProject_Summary);
                UpdateState(GameState.WORK_PROJECT);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayCourseSummary(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.COM_Course_Summary.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.COM_Course_Summary);
            }

        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.COM_Course_Summary.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.COM_Course_Summary);
                UpdateState(GameState.COURSE);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }

        }
    }
    public void DisplayWorkTypingGame(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.TypingWork.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.TypingWork);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.TypingWork.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.TypingWork);
            }
            
        }
    }
    public void DisplayAlphaTypingGame(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.TypingAlphaTest.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.TypingAlphaTest);

            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.TypingAlphaTest.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.TypingAlphaTest);
            }
            
        }
    }
    public void DisplayBetaTypingGame(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.TypingBetaTest.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.TypingBetaTest);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.TypingBetaTest.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.TypingBetaTest);
            }
            
        }
    }
    public void DisplayPlaceClothing(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_Clothing_Store.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_Clothing_Store);
            }

            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_Clothing_Store.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_Clothing_Store);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }          
        }
    }
    public void DisplayPlaceFood(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_Food_Store.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_Food_Store);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_Food_Store.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_Food_Store);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }

            
        }
    }
    public void DisplayPlaceMaterial(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_Material_Store.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_Material_Store);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_Material_Store.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_Material_Store);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayPlaceMystic(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_Mystic_Store.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_Mystic_Store);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_Mystic_Store.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_Mystic_Store);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }

        }
    }
    public void DisplayPlacePark(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_Park.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_Park);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_Park.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_Park);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayPlaceTeacher(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_Teacher_Home.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_Teacher_Home);
            }

        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_Teacher_Home.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_Teacher_Home);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayPlaceUniversity(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.Place_University.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.Place_University);
            }
            
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.Place_University.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.Place_University);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }
            
        }
    }
    public void DisplayReceiveTreasure(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.ReceiveItems.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.ReceiveItems);
            }

        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.ReceiveItems.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.ReceiveItems);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }

        }
    }
    public void DisplayStachInventory(bool active)
    {
        if (active)
        {
            if (!SceneManager.GetSceneByName(GameScene.StachInventory.ToString()).isLoaded)
            {
                if (SceneManager.GetSceneByName(GameScene.ReceiveItems.ToString()).isLoaded)
                {
                    UnLoadLevel(GameScene.ReceiveItems);
                }
                LoadLevelSceneWithOutLoadingScene(GameScene.StachInventory);
            }

        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.StachInventory.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.StachInventory);
                UpdateState(GameState.MAP);
                onLoadComplete?.Invoke(CurrentGameState, _previousGameState);
            }

        }
    }

    private GameState _tempGameStatePreviousDialougeScene;
    private GameScene _tempGameScene;
    public void DisplayDialouge(bool active)
    {
        if (active)
        {
            _tempGameStatePreviousDialougeScene = CurrentGameState;
            _tempGameScene = CurrentGameScene;
            if (!SceneManager.GetSceneByName(GameScene.HUD_Dialouge.ToString()).isLoaded)
            {
                LoadLevelSceneWithOutLoadingScene(GameScene.HUD_Dialouge);
            }
        }
        else
        {
            if (SceneManager.GetSceneByName(GameScene.HUD_Dialouge.ToString()).isLoaded)
            {
                UnLoadLevel(GameScene.HUD_Dialouge);
                UpdateState(_tempGameStatePreviousDialougeScene);
                _currentGameScene = _tempGameScene;
            }
        }
    }
    public void Transporting()
    {
        UpdateState(GameState.TRANSPORTING);
    }
    public void OpeningTreasure()
    {
        UpdateState(GameState.OPENINGTREASURE);
    }
    public void SleepLate()
    {
        UpdateState(GameState.SLEEPLATE);
    }
    public void HomeToMap()
    {
        UpdateState(GameState.ONTHEWAY);
    }
    #endregion


    private void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    private void UnLoadMenuSceneHasActived()
    {
        if (SceneManager.GetSceneByName(GameScene.Menu_Bag.ToString()).isLoaded)
        {
            UnLoadLevel(GameScene.Menu_Bag);
        }

        if (SceneManager.GetSceneByName(GameScene.Menu_Characters.ToString()).isLoaded)
        {
            UnLoadLevel(GameScene.Menu_Characters);
        }

        if (SceneManager.GetSceneByName(GameScene.Menu_Ideas.ToString()).isLoaded)
        {
            UnLoadLevel(GameScene.Menu_Ideas);
        }

        if (SceneManager.GetSceneByName(GameScene.Menu_Exit.ToString()).isLoaded)
        {
            UnLoadLevel(GameScene.Menu_Exit);
        }
    }

}
