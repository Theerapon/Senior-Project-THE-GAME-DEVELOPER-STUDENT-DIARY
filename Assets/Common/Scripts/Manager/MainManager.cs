using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : Manager<MainManager>
{
    [Header("Managers Prefabs")]
    public GameObject[] SystemPrefabs;
    List<GameObject> _instancedSystemPrefabs;

    [Header("Display")]
    public GameObject preCharacterInteractiveDisplay;
    public GameObject mainCamera;
    public GameObject timeDisplay;

    protected override void Awake()
    {
        _instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        
        if ((previousState == GameManager.GameState.DIALOGUE) && currentState == GameManager.GameState.SUMMARY)
        {
            TurnOffMainDisplay();
        }

        if (previousState == GameManager.GameState.SUMMARY && currentState == GameManager.GameState.RUNNING)
        {
            TurnOnMainDisplay();
        }
    }

    public void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
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

    private void TurnOnMainDisplay()
    {
        preCharacterInteractiveDisplay.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(true);
        timeDisplay.gameObject.SetActive(true);
    }

    private void TurnOffMainDisplay()
    {
        preCharacterInteractiveDisplay.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        timeDisplay.gameObject.SetActive(false);
    }

}
