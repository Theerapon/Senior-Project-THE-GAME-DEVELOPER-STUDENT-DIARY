using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    private SwitchScene _switchScene;

    private void Awake()
    {
        _switchScene = SwitchScene.Instance;
    }

    public void ExitMenu()
    {
        _switchScene.ExitToBootMenu(true);
    }

    public void ExitDesktop()
    {
        _switchScene.ExitGame();
    }
}
