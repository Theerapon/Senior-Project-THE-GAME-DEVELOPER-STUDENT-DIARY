using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public void RightClickAction(GameObject objClicked)
    {
        //when right click on obj also computer, item, idea
        switch (objClicked.tag)
        {
            case "Object":
                objClicked.GetComponent<ObjectClicked>().OnClick();
                break;
        }
    }
    
}
