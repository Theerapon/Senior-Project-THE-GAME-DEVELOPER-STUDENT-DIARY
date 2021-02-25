using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    #region Enums
    public enum Scene
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

    }
    public static Scene _currentLevelScene;

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


    private void Update()
    {
        if (_currentGameState == GameState.PREGAME)
        {
            return;
        }
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
            default:
                break;
        }

        OnGameStateChanged?.Invoke(_currentGameState, _previousGameState);
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_currentLevelScene == Scene.Boot)
        {
            UpdateState(GameState.PREGAME);
        }

        if (_currentLevelScene == Scene.Loading)
        {
            UpdateState(GameState.LOADING);
        }

        if (_currentLevelScene == Scene.Main)
        {
            //
            LoadLevelSceneWithOutLoadingScene(Scene.Level1);
        }

        if (_currentLevelScene == Scene.Level1)
        {
            UpdateState(GameState.RUNNING);
        }

        if (_currentLevelScene == Scene.Summary)
        {
            UpdateState(GameState.SUMMARY);
        }

    }

    #region Loading
    public void LoadLevelSceneWithOutLoadingScene(Scene sceneName)
    {
        ao = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + sceneName.ToString());
        }
        _currentLevelScene = sceneName;
        ao.completed += OnLoadOperationComplete;
    }

    public void LoadLevelWithLoadingScene(Scene sceneName)
    {
        onLoaderCallback = () => {
            StartCoroutine(LoadingScene(sceneName));
        };

        // Load the loading scene
        UpdateState(GameState.LOADING);
        SceneManager.LoadSceneAsync(Scene.Loading.ToString(), LoadSceneMode.Additive);
    }

    IEnumerator LoadingScene(Scene sceneName)
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
        UnLoadLevel(Scene.Loading);

        _currentLevelScene = sceneName;
        ao.completed += OnLoadOperationComplete;


    }

    public void UnLoadLevel(Scene sceneName)
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

    public void GotoSummaryDiary()
    {
        LoadLevelSceneWithOutLoadingScene(Scene.Summary);
        UpdateState(GameState.SUMMARY);
    }
    public void GotoCourse()
    {
        LoadLevelSceneWithOutLoadingScene(Scene.Course);
        UpdateState(GameState.COURSE);
    }
    public void GotoWorkProject()
    {
        LoadLevelSceneWithOutLoadingScene(Scene.WorkProject);
        UpdateState(GameState.WORKPROJECT);
    }

    public void GotoMainWithContiniueGameInNextDays()
    {
        UnLoadLevel(Scene.Summary);
        CloseDialogueToMain();
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSave();
        }
    }

    public void OpenDialogue(Scene scene)
    {
        LoadLevelSceneWithOutLoadingScene(scene);
        UpdateState(GameState.DIALOGUE);
    }


    public void FinishedDialogue(Scene nameScene)
    {
        UnLoadLevel(nameScene);
    }

    public void CloseDialogue(Scene nameScene)
    {
        UnLoadLevel(nameScene);
        CloseDialogueToMain();
    }

    private void CloseDialogueToMain()
    {
        _currentLevelScene = Scene.Main;
        UpdateState(GameState.RUNNING);
    }

    private void SwitchSceneToMain(bool loadingScene)
    {
        if (loadingScene)
        {
            LoadLevelWithLoadingScene(Scene.Main);
        } else
        {
            LoadLevelSceneWithOutLoadingScene(Scene.Main);
        }
    }

    #endregion

    #region Game State
    public void DisplayMenuUpdatedState()
    {
        if (_currentGameState == GameState.RUNNING)
        {
            UpdateState(GameState.DISPLAYMENU);
        }
        else if(_currentGameState == GameState.DISPLAYMENU && _previousGameState == GameState.RUNNING)
        {
            UpdateState(GameState.RUNNING);
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
