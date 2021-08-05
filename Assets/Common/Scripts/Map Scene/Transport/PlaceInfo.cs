using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInfo : MonoBehaviour
{
    [SerializeField] private Place _place = Place.Null;

    public Place Place { get => _place; }
}
