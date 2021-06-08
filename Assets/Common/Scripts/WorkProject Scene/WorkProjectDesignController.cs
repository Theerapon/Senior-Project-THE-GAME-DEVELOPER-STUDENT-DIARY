using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProjectDesignController : MonoBehaviour
{
    public void CancelDesignDocument()
    {
        SwitchScene.Instance.DisplayWorkProjectDesign(false);
    }
}
