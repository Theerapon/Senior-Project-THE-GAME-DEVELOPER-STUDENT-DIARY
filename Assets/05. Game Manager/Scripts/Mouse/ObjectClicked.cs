using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicked : MonoBehaviour, IClickable
{
    private void Start()
    { 

    }

    public void OnClick()
    {
        SpawnItem item = GetComponentInChildren<SpawnItem>();
        item.CreateSpawn();
        Debug.Log("Clicked");
    }


}
