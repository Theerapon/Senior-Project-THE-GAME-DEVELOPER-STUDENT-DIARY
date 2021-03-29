using UnityEngine;


public class HUDMenuController : MonoBehaviour
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

    protected void Start()
    {
        Reset();
        if(GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
        }
       // GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {

    }

    void Update()
    {
        if(gameManager != null)
        {
            if (gameManager.CurrentGameState == GameManager.GameState.RUNNING || gameManager.CurrentGameState == GameManager.GameState.HUDPLAYERMENU)
            {
                if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
                {

                    GameManager.Instance.DisplerHUD(ActivedBlur(), GameManager.GameScene.HUD_Player_Menu);

                }
            }

            if(gameManager.CurrentGameState == GameManager.GameState.STORAGE)
            {
                if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
                {

                    GameManager.Instance.DisplerHUD(false, GameManager.GameScene.HUD_Storage);

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

    private bool ActivedBlur()
    {
        if(_blur != null)
        {
            _blur.SetActive(!_blur.activeSelf);
        }

        return _blur.activeSelf;
    }

    private void Reset()
    {
        _blur.SetActive(false);
    }
}
