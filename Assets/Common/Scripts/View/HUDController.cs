using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    /*
    #region Defination
    [Header("Project")]
    [SerializeField] private GameObject _ProjectDisplayHolder;


    [Header("Menu")]
    [SerializeField] private GameObject _MenuHandler;

    [Header("Hotbar")]
    [SerializeField] private GameObject _HotbarHandler;
    #endregion
    */

    [SerializeField] private GameObject _blur;
    private GameManager gameManager;

    private GameManager.GameState previousGameStateMenu;

    protected void Start()
    {
        Reset();
        if(GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
        }
       GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.HOME_ACTION || currentState == GameManager.GameState.MENU)
        {
            ActivedBlur(true);
        }
    }

    void Update()
    {
        if(gameManager != null)
        {
            if (gameManager.CurrentGameState == GameManager.GameState.MENU)
            {
                if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
                {
                    switch (previousGameStateMenu)
                    {
                        case GameManager.GameState.HOME:
                            GameManager.Instance.DisplerMenu(ActivedBlur(false), GameManager.GameScene.HUD_Player_Menu, GameManager.GameState.HOME);
                            break;
                        case GameManager.GameState.MAP:
                            GameManager.Instance.DisplerMenu(ActivedBlur(false), GameManager.GameScene.HUD_Player_Menu, GameManager.GameState.MAP);
                            break;
                    }

                }
            } 
            else
            {
                //open menu home
                if (gameManager.CurrentGameState == GameManager.GameState.HOME)
                {
                    if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
                    {

                        GameManager.Instance.DisplerMenu(ActivedBlur(true), GameManager.GameScene.HUD_Player_Menu, GameManager.GameState.HOME);
                        previousGameStateMenu = GameManager.GameState.HOME;
                    }
                }

                //open menu map
                if (gameManager.CurrentGameState == GameManager.GameState.MAP)
                {
                    if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
                    {

                        GameManager.Instance.DisplerMenu(ActivedBlur(true), GameManager.GameScene.HUD_Player_Menu, GameManager.GameState.MAP);
                        previousGameStateMenu = GameManager.GameState.HOME;

                    }
                }
            }
            


            //close home action
            if (gameManager.CurrentGameState == GameManager.GameState.HOME_ACTION)
            {
                if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
                {
                        GameManager.Instance.DisplerHomeAction(ActivedBlur(false), gameManager.CurrentGameScene);

                }
            }
        }


    }

    /*
    #region Projects
    private void DisplayProject()
    {
        if (_ProjectDisplayHolder.activeSelf == true && _ProjectDisplayHolder != null)
        {
            _ProjectDisplayHolder.SetActive(false);
        }
        else
        {
            //SetDisplayProject();
            _ProjectDisplayHolder.SetActive(true);
        }
    }
    #endregion


    private void DisplayMenu()
    {
        if (_MenuHandler.activeSelf == true && _MenuHandler != null)
        {
            _MenuHandler.SetActive(false);
        }
        else
        {
            _MenuHandler.SetActive(true);
            MenuInGameManager.Instance.Reset();
        }
    }

    private void DisplayHotbar()
    {
        if (_HotbarHandler.activeSelf == true && _HotbarHandler != null)
        {
            _HotbarHandler.SetActive(false);
        }
        else
        {
            _HotbarHandler.SetActive(true);
        }
    }
    */

    private bool ActivedBlur(bool actived)
    {
        if(_blur != null)
        {
            _blur.SetActive(actived);
        }

        return _blur.activeSelf;
    }

    private void Reset()
    {
        _blur.SetActive(false);
    }
}
