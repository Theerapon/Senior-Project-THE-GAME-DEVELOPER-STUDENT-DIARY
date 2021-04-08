using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    #region Enums
    public enum GameScene
    {
        Boot,
        Loading,
        Home,
        Summary,
        Course,
        WorkProject,
        CourseAnimation,
        HUD_Info,
        Menu_Bag,
        Menu_Characters,
        Menu_Ideas,
        Menu_Friends,
        Menu_Exit,
        Home_Storage,
        Home_BED,
        Home_COMPUTER,
        Map

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
        LOADING,
        FIRST_SCENE,
        HOME,
        HOME_ACTION,
        COURSE,
        COURSE_NOTIFICATION,
        COURSE_LEARN_ANIMATION,
        COURSE_SUMMARY,
        SAVEING,
        DAIRY,
        CARD,
        HOME_DIALOUGE,
        ENDING,
        ENDING_DIALOUGE,
        ENDING_CREDIT,
        MAP,
        CHEST,
        SHOW_ITEM,
        INVENTORY_FULL,
        PLACE,
        PLACE_NOTIFICATION,
        PLACE_DIALOUGE,
        EXPLO_SUMMARY,
        PROJECT_DISCUSS,
        PROJECT_DISCUSS_DIALOUGE,
        PROJECT_DISCUSS_ANALYZE,
        CLASS,
        CLASS_MINIGAME,
        CLASS_DIALOUGE,
        GIFT,
        MENU,
        WORK_PROJECT,
        WORK_PROJECT_DESIGN,
        WORK_PROJECT_MINI_GAME,
        WORK_PROJECT_MINI_GAME_SUMMARY,
        WORK_PROJECT_ANIMATION,
        WORK_PROJECT_DIALOUGE,
        WORK_PROJECT_SUMMARY,
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

    #region Events Action and AsyncOperation 
    public Events.EventGameState OnGameStateChanged;
    private static Action onLoaderCallback;

    private static AsyncOperation ao;
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

        switch (_currentGameState)
        {
            case GameState.MENU:
                Time.timeScale = 0f;
                break;
            case GameState.HOME_ACTION:
                Time.timeScale = 0f;
                break;
            default:
                Time.timeScale = 1f;
                break;
        }
 
        OnGameStateChanged?.Invoke(_currentGameState, _previousGameState);
    }
    void UpdateScene(GameScene scene)
    {
        #region Boot
        if (scene == GameScene.Boot)
        {
            UpdateState(GameState.PREGAME);
        }
        #endregion

        #region Loading
        if (scene == GameScene.Loading)
        {
            UpdateState(GameState.LOADING);
        }
        #endregion

        #region Home
        if (scene == GameScene.Home && !SceneManager.GetSceneByName(GameScene.HUD_Info.ToString()).isLoaded)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.HUD_Info);
            UpdateState(GameState.HOME);
        } else if (scene == GameScene.Home)
        {
            UpdateState(GameState.HOME);
        }
        #endregion

        #region Menu
        if (scene == GameScene.Menu_Bag || scene == GameScene.Menu_Characters || scene == GameScene.Menu_Ideas 
            || scene == GameScene.Menu_Friends || scene == GameScene.Menu_Exit)
        {
            UpdateState(GameState.MENU);
        }
        #endregion

        #region Home Action
        if (scene == GameScene.Home_Storage || scene == GameScene.Home_COMPUTER || scene == GameScene.Home_BED)
        {
            UpdateState(GameState.HOME_ACTION);
        }
        #endregion

        #region Map
        if (scene == GameScene.Map)
        {
            UpdateState(GameState.MAP);
        }
        #endregion

        /*
        if (scene == GameScene.Summary)
        {
            UpdateState(GameState.SUMMARY);
        }

        if (scene == GameScene.CourseAnimation)
        {
            UpdateState(GameState.COURSEANIMATION);
        }
        */

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

    public void LoadLevelWithLoadingScene(GameScene sceneName)
    {
        onLoaderCallback = () => {
            StartCoroutine(LoadingScene(sceneName));
        };

        // Load the loading scene
        UpdateState(GameState.LOADING);
        SceneManager.LoadSceneAsync(GameScene.Loading.ToString(), LoadSceneMode.Additive);
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

        //after loading scene finished then unload loading scene
        UnLoadLevel(GameScene.Loading);

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
        LoadLevelWithLoadingScene(GameScene.Home);
    }

    public void StartGameWithContiniueGame()
    {
        LoadLevelWithLoadingScene(GameScene.Home);
    }

    public void DisplayHomeAction(bool actived, GameScene scene)
    {
        if (actived)
        {
            LoadLevelSceneWithOutLoadingScene(scene);
        }
        else
        {
            UnLoadLevel(scene);
            UpdateScene(GameScene.Home);
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
            UnLoadLevel(currentScene);
            UpdateState(toState);
            menu_hasDisplayed = false;
        }
    }

    public void DispleyMap(bool actived)
    {
        if (actived)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.Map);
        }
        else
        {
            UnLoadLevel(GameScene.Map);
            UpdateScene(GameScene.Home);
        }
    }


    public void GotoSummaryDiary()
    {
        //LoadLevelSceneWithOutLoadingScene(GameScene.Summary);
        //UpdateState(GameState.SUMMARY);
    }

    public void GotoCourse()
    {
        LoadLevelSceneWithOutLoadingScene(GameScene.Course);
        UpdateState(GameState.COURSE);
    }

    public void GotoCourseAnimation()
    {
        LoadLevelWithLoadingScene(GameScene.CourseAnimation);
    }

    public void GotoWorkProject()
    {
        //LoadLevelSceneWithOutLoadingScene(GameScene.WorkProject);
        //UpdateState(GameState.WORKPROJECT);
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

        if (SceneManager.GetSceneByName(GameScene.Menu_Friends.ToString()).isLoaded)
        {
            UnLoadLevel(GameScene.Menu_Friends);
        }

        if (SceneManager.GetSceneByName(GameScene.Menu_Exit.ToString()).isLoaded)
        {
            UnLoadLevel(GameScene.Menu_Exit);
        }
    }

}
