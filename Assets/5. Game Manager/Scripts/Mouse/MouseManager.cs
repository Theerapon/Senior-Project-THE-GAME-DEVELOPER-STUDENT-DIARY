using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public Texture2D pointer;
    public Texture2D target;

    public LayerMask clickableLayer;
    public Events.EventGameObject OnClickTarget;

    private bool _useDefaultCursor = false;

    private void Awake()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        _useDefaultCursor = (currentState != GameManager.GameState.RUNNING);
    }

    private void Update()
    {
        SetCursorDefalut();

        if (_useDefaultCursor)
        {
            return;
        }

        switch (GameManager.Instance.CurrentGameState)
        {
            case GameManager.GameState.RUNNING:
                MouseHandler();

                //on Click

                break;
        }
    }

    private void SetCursorDefalut()
    {
        Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
    }

    private void MouseHandler()
    {
        RaycastHit hit;
        bool clickObj = false;
        //Camera.main.ScreenPointToRay(Input.mousePosition)
        //check mouse holder
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            if (hit.collider.gameObject.tag == "Object")
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                clickObj = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (clickObj)
            {
                GameObject obj = hit.collider.gameObject;
                OnClickTarget.Invoke(obj);
            }

        }
        else if (Input.GetMouseButtonDown(1))
        {

        }
    }
}
    
