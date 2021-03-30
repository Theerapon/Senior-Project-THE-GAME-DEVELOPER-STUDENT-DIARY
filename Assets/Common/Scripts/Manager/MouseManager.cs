using UnityEngine;

public class MouseManager : Manager<MouseManager>
{

    public Texture2D pointer;
    public Texture2D target;

    public LayerMask clickableLayer;
    public Events.EventGameObject OnClickTarget;


    private bool _useDefaultCursor = false;
    private bool _useTargetCursor = false;


    private void Start()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        SetCursorDefalut();
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        SetCursorDefalut();
    }

    private void Update()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.HOME || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
        {
            MouseHandler();
        }
    }

    private void SetCursorDefalut()
    {
        Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
        _useDefaultCursor = true;
    }

    private void MouseHandler()
    {
        bool clickObj = false;
        //check mouse holder
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 50, clickableLayer.value);
        if (hit)
        {
            //set cursor
            clickObj = hit.collider.gameObject.GetComponent(typeof(IClickable)) != null;
            if (clickObj && _useTargetCursor == false)
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                _useDefaultCursor = false;
                _useTargetCursor = true;
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                if (clickObj)
                {
                    GameObject obj = hit.collider.gameObject;
                    OnClickTarget.Invoke(obj);
                }
            }
        }
        else
        {
            if (!_useDefaultCursor)
            {
                SetCursorDefalut();
                _useDefaultCursor = true;
                _useTargetCursor = false;
            }
        }

    }

    public void OnRightClick(GameObject objClicked)
    {
        switch (objClicked.tag)
        {
            case "obj_bed":
                objClicked.GetComponent<BedClickable>().OnClick();
                break;
            case "obj_calendar":
                objClicked.GetComponent<CalendarClickable>().OnClick();
                break;
            case "obj_com":
                objClicked.GetComponent<ComClickable>().OnClick();
                break;
            case "obj_door":
                objClicked.GetComponent<DoorClickable>().OnClick();
                break;
            case "obj_storage":
                objClicked.GetComponent<StorageClickable>().OnClick();
                break;

        }
    }


}
    
