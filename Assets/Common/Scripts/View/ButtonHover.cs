using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections;

public class ButtonHover : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] TMP_Text text;
    [SerializeField] private Color text_click_color;
    [SerializeField] private Color text_highlight_color;
    [SerializeField] private Color text_normal_color;
    [SerializeField] private bool _defaultNormalColor;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(GameStateChangedHandler);
        Initailizing(_defaultNormalColor);
    }

    private void GameStateChangedHandler(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        Initailizing(_defaultNormalColor);
    }

    private void Initailizing(bool normal)
    {
        if (normal)
        {
            Normal();
        }
        else
        {
            Highlight();
        }
    }

    public void Highlight()
    {
        text.color = text_highlight_color;
    }

    public void Normal()
    {
        text.color = text_normal_color;
    }

    public void Up()
    {
        Normal();
    }
    public void Down()
    {
        text.color = text_click_color;

    }

}
