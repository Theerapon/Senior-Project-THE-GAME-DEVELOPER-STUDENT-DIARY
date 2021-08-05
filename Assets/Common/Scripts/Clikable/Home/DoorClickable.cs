using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClickable : MonoBehaviour, IClickable
{

    public void OnClick()
    {
        GameManager.Instance.HomeToMap();
        SwitchScene.Instance.DispleyMap(true);
    }


}
