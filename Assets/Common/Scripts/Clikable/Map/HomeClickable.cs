using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeClickable : MonoBehaviour, IClickable
{
    [SerializeField] protected Camera _camera;

    private void Start()
    {
        GameManager.Instance.onHomeDisplay.AddListener(HandlerOnLoadGameComplete);
    }

    private void HandlerOnLoadGameComplete(bool homeDisplay)
    {
        _camera.gameObject.SetActive(!homeDisplay);
    }

    public void OnClick()
    {
        SwitchScene.Instance.DispleyMap(false);
    }
}
