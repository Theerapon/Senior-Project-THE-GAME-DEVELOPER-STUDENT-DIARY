using System.Collections;
using UnityEngine;

public class MouseManager : Manager<MouseManager>
{

    private const string INST_Obj_Bed = "obj_bed";
    private const string INST_Obj_Calendar = "obj_calendar";
    private const string INST_Obj_Computer = "obj_com";
    private const string INST_Obj_Door = "obj_door";
    private const string INST_Obj_Storage = "obj_storage";
    private const string INST_Place_Clothing = "Place_Clothing";
    private const string INST_Place_Food = "Place_Food";
    private const string INST_Place_Home = "Place_Home";
    private const string INST_Place_Material = "Place_Material";
    private const string INST_Place_Mystic = "Place_Mystic";
    private const string INST_Place_Park = "Place_Park";
    private const string INST_Place_Teacher = "Place_Teacher";
    private const string INST_Place_University = "Place_University";
    private const string INST_Place_Treasure = "Place_Treasure";

    public Texture2D pointer;
    public Texture2D target;

    public LayerMask clickableLayer;
    public Events.EventGameObjectOnClick OnClickTarget;
    public Events.EventGameObjectOnTriger OnTrigerTarget;
    public Events.EventGameObjectOnExitTriger OnExitTrigerTarget;


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
        _useDefaultCursor = false;
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.HOME || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
        {
            MouseHandler();
        }
    }

    private void SetCursorDefalut()
    {
        //Cursor.SetCursor(pointer, new Vector2(pointer.width / 2, pointer.height / 2), CursorMode.Auto);
        _useDefaultCursor = true;
    }

    private GameObject lastGameObjectOnTriger;
    private void MouseHandler()
    {
        bool clickObj = false;
        //check mouse holder
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, clickableLayer.value);
        if (hit)
        {
            //set cursor
            clickObj = hit.collider.gameObject.GetComponent(typeof(IClickable)) != null;
            if (clickObj && _useTargetCursor == false)
            {
                //Cursor.SetCursor(target, new Vector2(target.width / 2, target.height / 2), CursorMode.Auto);
                _useDefaultCursor = false;
                _useTargetCursor = true;
                lastGameObjectOnTriger = hit.collider.gameObject;
                OnTrigerTarget?.Invoke(lastGameObjectOnTriger);
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                if (clickObj)
                {
                    OnClickTarget?.Invoke(hit.collider.gameObject);
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
                if(lastGameObjectOnTriger != null)
                {
                    OnExitTrigerTarget?.Invoke(lastGameObjectOnTriger);
                }
            }
        }

    }

    public void OnRightClick(GameObject objClicked)
    {
        switch (objClicked.tag)
        {
            case INST_Obj_Bed:
                objClicked.GetComponent<BedClickable>().OnClick();
                break;
            case INST_Obj_Calendar:
                objClicked.GetComponent<CalendarClickable>().OnClick();
                break;
            case INST_Obj_Computer:
                objClicked.GetComponent<ComClickable>().OnClick();
                break;
            case INST_Obj_Door:
                objClicked.GetComponent<DoorClickable>().OnClick();
                break;
            case INST_Obj_Storage:
                objClicked.GetComponent<StorageClickable>().OnClick();
                break;
            case INST_Place_Clothing:
                objClicked.GetComponent<ClotingClickable>().OnClick();
                break;
            case INST_Place_Food:
                objClicked.GetComponent<FoodClickable>().OnClick();
                break;
            case INST_Place_Home:
                objClicked.GetComponent<HomeClickable>().OnClick();
                break;
            case INST_Place_Material:
                objClicked.GetComponent<MaterialClickable>().OnClick();
                break;
            case INST_Place_Mystic:
                objClicked.GetComponent<MysticClickable>().OnClick();
                break;
            case INST_Place_Park:
                objClicked.GetComponent<ParkClickable>().OnClick();
                break;
            case INST_Place_Teacher:
                objClicked.GetComponent<TeacherClickable>().OnClick();
                break;
            case INST_Place_University:
                objClicked.GetComponent<UniversityClickable>().OnClick();
                break;
            case INST_Place_Treasure:
                objClicked.GetComponent<TreasureClickable>().OnClick();
                break;
        }
    }

    public void OnTriger(GameObject objTriger)
    {
        MapPlace mapPlace = objTriger.GetComponent<MapPlace>();
        if(!ReferenceEquals(mapPlace, null))
        {
            mapPlace.OnTriger();
        }
    }

    public void OnExitTriger(GameObject objTriger)
    {
        MapPlace mapPlace = objTriger.GetComponent<MapPlace>();
        if (!ReferenceEquals(mapPlace, null))
        {
            mapPlace.OnExitTriger();
        }
    }
}

