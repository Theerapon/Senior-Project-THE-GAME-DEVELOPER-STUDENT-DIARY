using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Manager<SaveManager>
{
    public Events.EventSaveInitiated OnSaveInitiated;

    public void OnSave()
    {
        OnSaveInitiated?.Invoke();
    }
}
