
using UnityEngine;

public class BedClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        GameManager.Instance.OpenBedDialogue();

        if(SaveManager.Instance != null)
        {
            SaveManager.Instance.OnSave();
        }
    }

    
}
