using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBehavior : MonoBehaviour
{
    private SwitchScene _switchScene;

    private void Awake()
    {
        _switchScene = SwitchScene.Instance;
    }
    public void OpenTreasure()
    {
        _switchScene.DisplayReceiveTreasure(true);
    }
}
