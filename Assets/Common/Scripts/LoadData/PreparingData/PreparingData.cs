using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreparingData : MonoBehaviour
{
    #region Events
    public Events.EventOnInterpretData EventOnInterpretData;
    #endregion

    [SerializeField] private DataLoading [] dataLoadings;
    [SerializeField] private DataHandler [] dataHandlers;

    protected void Awake()
    {
        foreach (DataLoading datasLoading in dataLoadings)
        {
            datasLoading.onLoadDataCompleted.AddListener(HandlerLoadDataCompleted);
            //Debug.Log("DataLoading");
        }

        foreach (DataHandler dataHandler in dataHandlers)
        {
            dataHandler.EventOnInterpretDataComplete.AddListener(HandlerEventOnInterpretDataComplete);
            //Debug.Log("DataHandler " + dataHandler.gameObject.name);
        }
    }


    private void HandlerEventOnInterpretDataComplete()
    {
        int countInterpretComplete = 0;
        foreach (DataHandler dataHandler in dataHandlers)
        {
            if (dataHandler.HasFinished)
            {
                countInterpretComplete++;
                //Debug.Log(dataHandler.gameObject.name);
            }
        }

        //Debug.Log(string.Format("Interpreting {0}/{1}", countInterpretComplete, dataHandlers.Length));

        if (countInterpretComplete >= dataHandlers.Length && !SceneManager.GetSceneByName(GameManager.GameScene.Home.ToString()).isLoaded)
        {
            GameManager.Instance.DisplayHome();
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

        //Debug.Log(string.Format("Downloading {0}/{1}", countLoadComplete, dataLoadings.Length));
        
        if(countLoadComplete >= dataLoadings.Length)
        {
            EventOnInterpretData?.Invoke();
        }
        
    }

}
