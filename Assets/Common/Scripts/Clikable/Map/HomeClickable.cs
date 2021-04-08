using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeClickable : MonoBehaviour, IClickable
{
    [SerializeField] protected Camera _camera;

    public void OnClick()
    {
        _camera.gameObject.SetActive(false);
        GameManager.Instance.DispleyMap(false);
    }
}
