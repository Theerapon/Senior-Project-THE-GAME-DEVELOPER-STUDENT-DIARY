using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void RightClickAction(GameObject objClicked)
    {
        //distance
        float dist = Vector3.Distance(objClicked.transform.position, transform.position);
        
        if(dist < 2.5f)
        {
            //when right click on obj also computer, item, idea
            switch (objClicked.tag)
            {
                case "Object":
                    objClicked.GetComponent<TestClickable>().OnClick();
                    break;
                case "Bed":
                    objClicked.GetComponent<BedClickable>().OnClick();
                    break;
                case "Computer":
                    objClicked.GetComponent<ComputerClickable>().OnClick();
                    break;

            }
        }


    }
    
}
