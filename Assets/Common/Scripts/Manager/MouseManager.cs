using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : Manager<MouseManager>
{

    public Texture2D pointer;
    public Texture2D target;

    public LayerMask clickableLayer;
    public Events.EventGameObject OnClickTarget;

    private PlayerController playerController;

    private bool _useDefaultCursor = false;


    private void Start()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        playerController = GameObject.FindObjectOfType<PlayerController>();
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
        //check mouse holder
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            //set cursor
            clickObj = hit.collider.gameObject.GetComponent(typeof(IClickable)) != null;
            if (clickObj)
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }


            //clicked
            if (Input.GetMouseButtonDown(0))
            {

            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (clickObj)
                {
                    GameObject obj = hit.collider.gameObject;
                    OnClickTarget.Invoke(obj);
                }
            }
        }

    }

    public void OnRightClick(GameObject objClicked)
    {
        playerController.RightClickAction(objClicked);
    }


}
    
