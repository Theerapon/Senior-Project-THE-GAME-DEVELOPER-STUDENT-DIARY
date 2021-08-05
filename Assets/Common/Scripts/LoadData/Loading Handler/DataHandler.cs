using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public Events.EventOnInterpretDataComplete EventOnInterpretDataComplete;
    protected bool hasFinished;
    public bool HasFinished { get => hasFinished; }
}
