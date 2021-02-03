using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClickable : MonoBehaviour, IClickable
{
    private void Start()
    { 

    }

    public void OnClick()
    {
        SpawnItem item = GetComponentInChildren<SpawnItem>();
        item.CreateSpawn();
    }


}
