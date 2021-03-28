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
        Main,
        Summary,
        Level1,
        UI_BED,
        UI_COMPUTER,
        Course,
        WorkProject,
        CourseAnimation,
        HUD_Player_Info,
        HUD_Player_Menu,

    }
    public static GameScene _currentGameScene;

    public enum GameState
    {
        PREGAME,
        LOADING,
        RUNNING,
        DISPLAYMENU,
        DIALOGUE,
        SUMMARY,
        COURSE,
        WORKPROJECT,
        COURSEANIMATION,
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
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;
            case GameState.LOADING:
                Time.timeScale = 0f;
                break;
            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;
            case GameState.DISPLAYMENU:
                Time.timeScale = 0f;
                break;
            case GameState.DIALOGUE:
                Time.timeScale = 0f;
                break;
            case GameState.SUMMARY:
                Time.timeScale = 1f;
                break;
            case GameState.COURSE:
                Time.timeScale = 1f;
                break;
            case GameState.COURSEANIMATION:
                Time.timeScale = 1f;
                break;
            default:
                Time.timeScale = 1f;
                break;
        }

        OnGameStateChanged?.Invoke(_currentGameState, _previousGameState);
    }
    void UpdateScene(GameScene scene)
    {
        if (scene == GameScene.Boot)
        {
            UpdateState(GameState.PREGAME);
        }

        if (scene == GameScene.Loading)
        {
            UpdateState(GameState.LOADING);
        }

        if (scene == GameScene.Main && !SceneManager.GetSceneByName(GameScene.HUD_Player_Info.ToString()).isLoaded)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.HUD_Player_Info);
            UpdateState(GameState.RUNNING);
        }
        else
        {
            UpdateState(GameState.RUNNING);
        }

        if (scene == GameScene.HUD_Player_Menu)
        {
            UpdateState(GameState.DISPLAYMENU);
        }

        if (scene == GameScene.Summary)
        {
            UpdateState(GameState.SUMMARY);
        }

        if (scene == GameScene.CourseAnimation)
        {
            UpdateState(GameState.COURSEANIMATION);
        }
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        UpdateScene(_currentGameScene);
    }

    #region Loading
    public void LoadLevelSceneWithOutLoadingScene(GameScene sceneName)
    {
        ao = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + sceneName.ToString());
        }
        _currentGameScene = sceneName;
        ao.completed += OnLoadOperationComplete;
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

    public void UnLoadLevel(GameScene sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName.ToString());
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + sceneName.ToString());
            return;
        }
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
        SwitchSceneToMain(true);
    }

    public void StartGameWithContiniueGame()
    {
        SwitchSceneToMain(true);
    }

    public void OpenPlayerMenu(bool actived)
    {
        if (actived)
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.HUD_Player_Menu);
        }
        else
        {
            UnLoadLevel(GameScene.HUD_Player_Menu);
            UpdateScene(GameScene.Main);
        }
    }

    public void GotoSummaryDiary()
    {
        LoadLevelSceneWithOutLoadingScene(GameScene.Summary);
        UpdateState(GameState.SUMMARY);
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
        LoadLevelSceneWithOutLoadingScene(GameScene.WorkProject);
        UpdateState(GameState.WORKPROJECT);
    }

    public void GotoMainWithContiniueGameInNextDays()
    {
        UnLoadLevel(GameScene.Summary);
        CloseToMain();
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSave();
        }
    }

    public void BackFromCourseToMain()
    {
        UnLoadLevel(GameScene.Course);
        CloseToMain();

    }

    public void BackFromCourseAnimationToCourse()
    {
        UnLoadLevel(GameScene.CourseAnimation);
        UpdateState(GameState.COURSE);
    }

    public void OpenDialogue(GameScene scene)
    {
        LoadLevelSceneWithOutLoadingScene(scene);
        UpdateState(GameState.DIALOGUE);
    }


    public void FinishedDialogue(GameScene nameScene)
    {
        UnLoadLevel(nameScene);
    }

    public void CloseDialogue(GameScene nameScene)
    {
        UnLoadLevel(nameScene);
        CloseToMain();
    }

    private void CloseToMain()
    {
        _currentGameScene = GameScene.Main;
        UpdateState(GameState.RUNNING);
    }

    private void SwitchSceneToMain(bool loadingScene)
    {
        if (loadingScene)
        {
            LoadLevelWithLoadingScene(GameScene.Main);
        } else
        {
            LoadLevelSceneWithOutLoadingScene(GameScene.Main);
        }
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

}
