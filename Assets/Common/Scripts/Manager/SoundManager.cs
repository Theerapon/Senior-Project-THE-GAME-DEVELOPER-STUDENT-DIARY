using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager<SoundManager>
{
    [Header("Manager")]
    [SerializeField] private GameManager _gameManager;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip _mainSceneClip;
    [SerializeField] private AudioClip _sleepSceneClip;
    [SerializeField] private AudioClip _homeSceneClip;
    [SerializeField] private AudioClip _mapSceneClip;
    [SerializeField] private AudioClip _storeSceneClip;
    [SerializeField] private AudioClip _mysticSceneClip;
    [SerializeField] private AudioClip _universitySceneClip;
    [SerializeField] private AudioClip _teacherSecneClip;
    [SerializeField] private AudioClip _parkSceneClip;
    [SerializeField] private AudioClip _workingSceneClip;
    [SerializeField] private AudioClip _courseSceneClip;
    [SerializeField] private AudioClip _workTypingGameSceneClip;
    [SerializeField] private AudioClip _alphaTypingGameSceneClip;
    [SerializeField] private AudioClip _betaTypingGameSceneClip;
    [SerializeField] private AudioClip _endgameSceneClip;
    [SerializeField] private AudioClip _summarySceneClip;

    [Header("Audio Source")]
    [SerializeField] private AudioSource _audioSource;

    private AudioClip _currentAudio;

    protected override void Awake()
    {
        base.Awake();
        _gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        
    }

    private void Start()
    {
        ChangedAudio(_mainSceneClip);
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if (current == GameManager.GameState.PREGAME)
        {
            ChangedAudio(_mainSceneClip);
        }
        else if (current == GameManager.GameState.HOME)
        {
            ChangedAudio(_homeSceneClip);
        }
        else if (current == GameManager.GameState.SLEEPLATE || current == GameManager.GameState.SAVEING)
        {
            ChangedAudio(_sleepSceneClip);
        }
        else if (current == GameManager.GameState.MAP)
        {
            ChangedAudio(_mapSceneClip);
        }
        else if (current == GameManager.GameState.PLACE
            && _gameManager.CurrentGameScene == GameManager.GameScene.Place_Park)
        {
            ChangedAudio(_parkSceneClip);
        }
        else if (current == GameManager.GameState.PLACE
            && _gameManager.CurrentGameScene == GameManager.GameScene.Place_Teacher_Home)
        {
            ChangedAudio(_teacherSecneClip);
        }
        else if (current == GameManager.GameState.PLACE
            && _gameManager.CurrentGameScene == GameManager.GameScene.Place_Mystic_Store)
        {
            ChangedAudio(_mysticSceneClip);
        }
        else if (current == GameManager.GameState.PLACE
            && _gameManager.CurrentGameScene == GameManager.GameScene.Place_University)
        {
            ChangedAudio(_universitySceneClip);
        }
        else if(current == GameManager.GameState.PLACE)
        {
            ChangedAudio(_storeSceneClip);
        }
        else if (current == GameManager.GameState.WORK_PROJECT)
        {
            ChangedAudio(_workingSceneClip);
        }
        else if (current == GameManager.GameState.COURSE)
        {
            ChangedAudio(_courseSceneClip);
        }
        else if (current == GameManager.GameState.WORK_PROJECT_MINI_GAME && _gameManager.CurrentGameScene == GameManager.GameScene.TypingWork)
        {
            ChangedAudio(_workTypingGameSceneClip);
        }
        else if (current == GameManager.GameState.WORK_PROJECT_MINI_GAME && _gameManager.CurrentGameScene == GameManager.GameScene.TypingAlphaTest)
        {
            ChangedAudio(_alphaTypingGameSceneClip);
        }
        else if (current == GameManager.GameState.WORK_PROJECT_MINI_GAME && _gameManager.CurrentGameScene == GameManager.GameScene.TypingBetaTest)
        {
            ChangedAudio(_betaTypingGameSceneClip);
        }
        else if (current == GameManager.GameState.EndGame)
        {
            ChangedAudio(_storeSceneClip);
        }
        else if(current == GameManager.GameState.PREPARINGDATA)
        {
            ChangedAudio(null);
        }
        else if (current == GameManager.GameState.COURSE_SUMMARY 
            || current == GameManager.GameState.WORK_PROJECT_SUMMARY
            || current == GameManager.GameState.MEETING_PROJECT)
        {
            ChangedAudio(_summarySceneClip);
        }
        else
        {
            if (!CheckAudio() && current != GameManager.GameState.PREPARINGDATA)
            {
                ChangedAudio(_mainSceneClip);
            }
        }

    }

    private void ChangedAudio(AudioClip audioClip)
    {
        if(audioClip == null)
        {
            _audioSource.clip = null;
            _audioSource.Stop();
            _currentAudio = null;
            return;
        }
        else
        {
            if(_currentAudio != audioClip || _currentAudio == null)
            {
                _audioSource.clip = audioClip;
                _audioSource.Play();
            }
        }
        _currentAudio = audioClip;
    }

    private bool CheckAudio()
    {
        if(_audioSource.clip != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
