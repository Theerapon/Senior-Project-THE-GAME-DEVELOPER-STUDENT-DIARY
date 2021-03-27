
using UnityEngine;

public class BedClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("bed");
        //GameManager.Instance.OpenDialogue(GameManager.Scene.UI_BED);
    }

    
}
