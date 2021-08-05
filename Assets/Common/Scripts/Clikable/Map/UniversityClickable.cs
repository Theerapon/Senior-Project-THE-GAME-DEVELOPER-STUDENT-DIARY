using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversityClickable : MonoBehaviour, IClickable
{
    [SerializeField] MapPlace mapPlace;
    public void OnClick()
    {
        mapPlace.OnClick();
    }

}
