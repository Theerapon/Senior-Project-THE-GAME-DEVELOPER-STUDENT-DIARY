using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClickable : MonoBehaviour, IClickable
{
    [SerializeField] MapPlace mapPlace;
    public void OnClick()
    {
        mapPlace.OnClick();
    }


}
