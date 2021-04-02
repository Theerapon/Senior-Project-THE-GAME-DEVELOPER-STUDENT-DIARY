using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ButtonHover : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] TMP_Text text;
    [SerializeField] Color text_color_highlight;

    private Color normal = new Color(1, 1, 1, 1f);

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(GameStateChangedHandler);
    }

    private void GameStateChangedHandler(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        if(currentGameState == GameManager.GameState.MENU)
        {
            Normal();
        }
    }

    public void Highlight()
    {
        text.color = text_color_highlight;
    }

    public void Normal()
    {
        text.color = normal;
    }
}
