using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparingData : MonoBehaviour
{
    public DataLoading [] dataLoadings;

    private void Awake()
    {
        foreach (DataLoading datasLoading in dataLoadings)
        {
            datasLoading.onLoadDataCompleted.AddListener(HandlerLoadDataCompleted);
        }
    }


    private void HandlerLoadDataCompleted()
    {
        int countLoadComplete = 0;
        foreach (DataLoading datasLoading in dataLoadings)
        {
            if (datasLoading.GethasFinished())
            {
                countLoadComplete++;
            }
        }

        Debug.Log(string.Format("Downloading {0}/{1}", countLoadComplete, dataLoadings.Length));
    }

}
