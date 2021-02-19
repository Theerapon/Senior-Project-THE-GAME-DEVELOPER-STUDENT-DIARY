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
        Level1
    }
    public static Scene _currentLevelScene;

    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSE,
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
    private static AsyncOperation aoLoading;
    private static AsyncOperation aoSub;
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

            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;
            case GameState.PAUSE:
                Time.timeScale = 1.0f;
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(_currentGameState, _previousGameState);
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {

        if (_currentLevelScene == Scene.Main)
        {
            LoadLevelSceneWithOutLoadingScene(Scene.Level1);
        }

        if (_currentLevelScene == Scene.Level1)
        {
            UpdateState(GameState.RUNNING);
        }

        if (aoLoading.isDone)
        {
            aoLoading = SceneManager.UnloadSceneAsync(Scene.Loading.ToString());
        }
    }

    public void LoadLevelSceneWithOutLoadingScene(Scene sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
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
        aoLoading = SceneManager.LoadSceneAsync(Scene.Loading.ToString(), LoadSceneMode.Additive);
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

    public void NewGame()
    {
        LoadLevelWithLoadingScene(Scene.Main);
    }

    public void ContiniueGame()
    {
        LoadLevelWithLoadingScene(Scene.Main);
    }

    public void PuaseGame()
    {
        if (_currentGameState == GameState.RUNNING)
        {
            UpdateState(GameState.PAUSE);
        }
        else if(_currentGameState == GameState.PAUSE && _previousGameState == GameState.RUNNING)
        {
            UpdateState(GameState.RUNNING);
        }

    }


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
