using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    protected KeyCode keyCode = KeyCode.E;


    protected void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(keyCode))
            {
                OnTrigger();
            }
        }
    }

    protected virtual void OnTrigger()
    {

        Debug.Log("Trigger");
    }

}
