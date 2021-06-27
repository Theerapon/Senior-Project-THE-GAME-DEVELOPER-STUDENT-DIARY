using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasportingAnimController : MonoBehaviour
{
    [SerializeField] TransportController transportController;

    public void TransportingFinished()
    {
        transportController.TransportFinished();
    }
}
