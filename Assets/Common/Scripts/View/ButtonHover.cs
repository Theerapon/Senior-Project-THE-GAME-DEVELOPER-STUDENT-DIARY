using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ButtonHover : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] TMP_Text text;
    [SerializeField] private Color text_highlight_color;
    [SerializeField] private Color text_normal_color;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(GameStateChangedHandler);
        Normal();
    }

    private void GameStateChangedHandler(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        Normal();
    }

    public void Highlight()
    {
        text.color = text_highlight_color;
    }

    public void Normal()
    {
        text.color = text_normal_color;
    }
}
