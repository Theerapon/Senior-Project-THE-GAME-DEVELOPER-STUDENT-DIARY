using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Events.EventOnOpenMenu OnGameOpenMaenu;

    [Header("Blur")]
    [SerializeField] private GameObject _blur;

    [Header("Camera")]
    [SerializeField] private GameObject _camera;


    private GameManager gameManager;
    private SwitchScene switchScene;

    private GameManager.GameState previousGameStateMenu;

    private bool hasDisplayed;

    protected void Start()
    {
        Reset();
        if(GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
        }
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        switchScene = SwitchScene.Instance;
        hasDisplayed = false;
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.HOME_ACTION || currentState == GameManager.GameState.MENU || currentState == GameManager.GameState.WORK_PROJECT_SUMMARY)
        {
            ActivedBlur(true);
            ActiveCamera(true);
        }
        else if (currentState == GameManager.GameState.MAP  || currentState == GameManager.GameState.WORK_PROJECT_MINI_GAME)
        {
            ActivedBlur(false);
            ActiveCamera(false);

        }
        else if (currentState == GameManager.GameState.HOME)
        {
            ActivedBlur(false);
            ActiveCamera(true);
        }
        else if (currentState == GameManager.GameState.PLACE)
        {
            ActivedBlur(true);
            ActiveCamera(false);
            hasDisplayed = true;
        }
        else if(currentState == GameManager.GameState.TRANSPORTING || currentState == GameManager.GameState.OPENINGTREASURE)
        {
            ActivedBlur(true);
            ActiveCamera(false);
        }

    }

    void Update()
    {
        if (gameManager != null)
        {

            if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
            {
                if (hasDisplayed)
                {
                    EscBack();
                }
                else
                {
                    if(GameManager.Instance.CurrentGameState == GameManager.GameState.HOME || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
                    {
                        EscOpen();
                    }
                }
            }


        }

    }


    private bool ActivedBlur(bool active)
    {
        if(_blur.activeSelf != active)
        {
            _blur.SetActive(active);
        }
        
        return _blur.activeSelf;
    }

    private void Reset()
    {
        _blur.SetActive(false);
    }
    private void ActiveCamera(bool active)
    {
        if(_camera.activeSelf != active)
        {
            _camera.SetActive(active);
        }
    }

    private void DisplayMenu(bool action, GameManager.GameScene currentGameScene)
    {
        switchScene.DisplayMenu(action, currentGameScene, previousGameStateMenu);
        hasDisplayed = true;
    }

    private void DisplayHomeAction(bool action, GameManager.GameScene currentGameScene)
    {
        switchScene.DisplayHomeAction(ActivedBlur(action), currentGameScene);
        hasDisplayed = true;
    }

    public GameManager.GameState GetPreviousGameStateMenu()
    {
        return previousGameStateMenu;
    }

    public void SetPreviousGameStateMenu(GameManager.GameState gameState)
    {
        previousGameStateMenu = gameState;
    }

    public void Close(GameManager.GameScene gameScene)
    {
        //close menu
        if (gameManager.CurrentGameState == GameManager.GameState.MENU)
        {
            DisplayMenu(ActivedBlur(false), gameScene);
            hasDisplayed = false;
        }
        else if (gameManager.CurrentGameState == GameManager.GameState.HOME_ACTION)
        {
            DisplayHomeAction(ActivedBlur(false), gameScene);
            hasDisplayed = false;
        }
        else if(gameManager.CurrentGameState == GameManager.GameState.COURSE_NOTIFICATION)
        {
            switchScene.DisplayCourseNotification(false);
            hasDisplayed = true;
        }
        else if(gameManager.CurrentGameState == GameManager.GameState.COURSE)
        {
            switchScene.DisplayCourse(false);
            hasDisplayed = false;
        }
        else if (gameManager.CurrentGameState == GameManager.GameState.WORK_PROJECT)
        {
            switchScene.DisplayWorkProject(false);
            hasDisplayed = false;
        }
        else if (gameManager.CurrentGameState == GameManager.GameState.PLACE)
        {
            DisplayPlace(gameScene, false);
            hasDisplayed = false;
        }

    }
    public void DisplayPlace(GameManager.GameScene gameScene, bool active)
    {
        switch (gameScene)
        {
            case GameManager.GameScene.Place_Clothing_Store:
                switchScene.DisplayPlaceClothing(active);
                break;
            case GameManager.GameScene.Place_Food_Store:
                switchScene.DisplayPlaceFood(active);
                break;
            case GameManager.GameScene.Place_Material_Store:
                switchScene.DisplayPlaceMaterial(active);
                break;
            case GameManager.GameScene.Place_Mystic_Store:
                switchScene.DisplayPlaceMystic(active);
                break;
            case GameManager.GameScene.Place_Park:
                switchScene.DisplayPlacePark(active);
                break;
            case GameManager.GameScene.Place_Teacher_Home:
                switchScene.DisplayPlaceTeacher(active);
                break;
            case GameManager.GameScene.Place_University:
                switchScene.DisplayPlaceUniversity(active);
                break;
            default:
                break;
        }
    }
    public void OpenMenu(GameManager.GameScene gameScene)
    {
        //open menu home
        if (gameManager.CurrentGameState == GameManager.GameState.HOME)
        {
            previousGameStateMenu = GameManager.GameState.HOME;
        }

        //open menu map
        if (gameManager.CurrentGameState == GameManager.GameState.MAP)
        {
            previousGameStateMenu = GameManager.GameState.MAP;
        }

        DisplayMenu(ActivedBlur(true), gameScene);
    }

    public void OpenHomeAction(GameManager.GameScene gameScene)
    {
        DisplayHomeAction(ActivedBlur(true), gameScene);
    }

    private void EscOpen()
    {
        //Esc key open Bag first anyway
        GameManager.GameScene scene = GameManager.GameScene.Menu_Bag;
        OnGameOpenMaenu?.Invoke(scene);
        OpenMenu(scene);

    }

    private void EscBack()
    {
        //Esc key close current scene
        Close(GameManager.Instance.CurrentGameScene);
    }
}
