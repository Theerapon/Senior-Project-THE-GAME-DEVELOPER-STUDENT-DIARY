using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public enum GameState
    {
        RUNNING
    }

    public GameObject[] SystemPrefabs;

    List<GameObject> _instancedSystemPrefabs;
    GameState _currentGameState = GameState.RUNNING;
    string _currentLevelName = string.Empty;

    private PlayerMovement playerMovement;

    private PlayerMovement player
    {
        get
        {
            if(null == playerMovement)
            {
                playerMovement = FindObjectOfType<PlayerMovement>();
            }
            return playerMovement;
        }
    }

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set { _currentGameState = value; }
    }

    private void Start()
    {
        _instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();
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

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }


        _currentLevelName = levelName;
    }

    public void StartGame()
    {
        LoadLevel("Main");
    }
}
