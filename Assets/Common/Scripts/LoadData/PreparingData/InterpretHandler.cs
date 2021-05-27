using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretHandler : MonoBehaviour
{
    #region Events
    public Events.EventOnPreparingInterpretData EventOnPreparingInterpretData;
    #endregion

    [SerializeField] private PreparingData preparingData;

    // Start is called before the first frame update
    void Start()
    {
        preparingData.EventOnInterpretData.AddListener(OnEventInterpretHandler);
    }

    private void OnEventInterpretHandler()
    {
        EventOnPreparingInterpretData?.Invoke();
    }

}
