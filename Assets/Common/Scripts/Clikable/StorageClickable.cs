﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("storage");
    }
}