using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StachController : MonoBehaviour
{
    private SwitchScene _switchScene;
    [SerializeField] private GameObject _notificationGameObject;
    [SerializeField] private GameObject _nextButton;

    private void Awake()
    {
        _switchScene = SwitchScene.Instance;
        ActiveNotification(false);
        ActiveNextButton(true);
    }

    public void Continue()
    {
        ActiveNotification(true);
        ActiveNextButton(false);
    }

    public void Confirm()
    {
        _switchScene.DisplayStachInventory(false);
    }

    public void Cancel()
    {
        ActiveNotification(false);
        ActiveNextButton(true);
    }

    private void ActiveNotification(bool active)
    {
        if(_notificationGameObject.activeSelf != active)
        {
            _notificationGameObject.SetActive(active);
        }

    }

    private void ActiveNextButton(bool active)
    {
        if (_nextButton.activeSelf != active)
        {
            _nextButton.SetActive(active);
        }
    }
}
