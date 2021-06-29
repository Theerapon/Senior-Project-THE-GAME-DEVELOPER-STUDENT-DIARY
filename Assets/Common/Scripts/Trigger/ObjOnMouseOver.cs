using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnMouseOver : MonoBehaviour
{
    private GameManager _gameManager;
    Animator animator;
    private GameManager.GameState _currentGameState;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        _currentGameState = current;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void OnMouseExit()
    {
        if(_currentGameState == GameManager.GameState.MAP || _currentGameState == GameManager.GameState.HOME)
        {
            animator.SetBool("hover", false);
        }
        
    }

    private void OnMouseEnter()
    {
        if (_currentGameState == GameManager.GameState.MAP || _currentGameState == GameManager.GameState.HOME)
        {
            animator.SetBool("hover", true);
        }
        
    }


}
