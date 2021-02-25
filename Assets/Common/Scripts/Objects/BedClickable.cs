
using UnityEngine;

public class BedClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        GameManager.Instance.OpenDialogue(GameManager.Scene.UI_BED);
    }

    
}
