using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteItems_DataHandler : DataHandler
{
    protected Dictionary<string, FavoriteItems_Template> favoriteItemsDic;
    [SerializeField] private FavoriteItemsVM favoriteItemsVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, FavoriteItems_Template> GetFavoriteItemDic
    {
        get { return favoriteItemsDic; }
    }

    protected void Awake()
    {
        favoriteItemsDic = new Dictionary<string, FavoriteItems_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        favoriteItemsDic = favoriteItemsVM.Interpert();
        if (!ReferenceEquals(favoriteItemsDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }

    }
}
