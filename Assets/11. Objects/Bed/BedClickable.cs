
using UnityEngine;

public class BedClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("Clicked");
    }

    
}
