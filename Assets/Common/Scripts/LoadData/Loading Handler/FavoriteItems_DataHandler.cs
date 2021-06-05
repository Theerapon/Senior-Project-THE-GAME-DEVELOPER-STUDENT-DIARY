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
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Favorite Item interpret completed");
        //foreach (KeyValuePair<string, FavortieItems_Template> favoriteItem in favoriteItemsDic)
        //{
        //    for(int i = 0; i < favoriteItem.Value.ItemLikeId.Count; i++)
        //    {
        //        Debug.Log(string.Format("ID {0}, Like Item ID = {1}, {2} feel {3}", 
        //            favoriteItem.Value.Id, favoriteItem.Value.ItemLikeId[i].ItemId, 
        //            favoriteItem.Value.ItemLikeId[i].Dialogue, favoriteItem.Value.ItemLikeId[i].Feel));
        //    }

        //    for (int i = 0; i < favoriteItem.Value.ItemUnLikeId.Count; i++)
        //    {
        //        Debug.Log(string.Format("ID {0}, UnLike Item ID = {1}, {2} feel {3}",
        //            favoriteItem.Value.Id, favoriteItem.Value.ItemUnLikeId[i].ItemId,
        //            favoriteItem.Value.ItemUnLikeId[i].Dialogue, favoriteItem.Value.ItemUnLikeId[i].Feel));
        //    }

        //    for (int i = 0; i < favoriteItem.Value.ItemExceptId.Count; i++)
        //    {
        //        Debug.Log(string.Format("ID {0}, Except Item ID = {1}, {2} feel {3}",
        //            favoriteItem.Value.Id, favoriteItem.Value.ItemExceptId[i].ItemId,
        //            favoriteItem.Value.ItemExceptId[i].Dialogue, favoriteItem.Value.ItemExceptId[i].Feel));
        //    }

        //}
    }
}
