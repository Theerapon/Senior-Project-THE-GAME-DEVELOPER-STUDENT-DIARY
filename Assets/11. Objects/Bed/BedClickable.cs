
using UnityEngine;

public class BedClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        if(SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSave();
        }
    }

    
}
