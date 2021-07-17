using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections;

public class ButtonHover : MonoBehaviour
{
    public Events.EventOnButtonChange OnButtonChange;

    [Header("Title")]
    [SerializeField] TMP_Text text;
    [SerializeField] private Color text_click_color;
    [SerializeField] private Color text_highlight_color;
    [SerializeField] private Color text_normal_color;
    [SerializeField] private bool _defaultNormalColor;

    private bool isSelected = false;
    public bool IsSelected { get => isSelected; }

    private void Awake()
    {
        Initailizing(_defaultNormalColor);
    }


    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(GameStateChangedHandler);
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
        isSelected = true;
        text.color = text_highlight_color;
        OnButtonChange?.Invoke(this, true);
    }

    public void Normal()
    {
        text.color = text_normal_color;
        isSelected = false;
        OnButtonChange?.Invoke(this, false);
    }

    public void Up()
    {
        Normal();
    }
    public void Down()
    {
        text.color = text_click_color;

    }

    public void SetIsSelected()
    {
        isSelected = true;
        text.color = text_highlight_color;
    }

    public void UnSelected()
    {
        text.color = text_normal_color;
        isSelected = false;
    }

}
