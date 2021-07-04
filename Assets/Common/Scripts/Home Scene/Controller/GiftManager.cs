using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FeelNpc { Normal, Like, Unlike, Except }
public class GiftManager : MonoBehaviour
{
    [Header("Icon")]
    [SerializeField] private Sprite _like;
    [SerializeField] private Sprite _unlike;
    [SerializeField] private Sprite _except;
    [SerializeField] private Sprite _normal;

    private const int INST_VALUE_FAVORITE_LIKE = 6;
    private const int INST_VALUE_FAVORITE_UnLIKE = 7;
    private const int INST_VALUE_FAVORITE_EXCEPT = 12;
    private const int INST_VALUE_FAVORITE_NORMAL = 3;

    private NpcsController _npcsController;
    [SerializeField] private NotificationController _notificationController;

    private void Awake()
    {
        _npcsController = NpcsController.Instance;
    }

    public bool Gift(string itemId, string npcId)
    {
        if(!ReferenceEquals(_npcsController, null))
        {
            if (_npcsController.NpcsDic.ContainsKey(npcId))
            {
                Npc npc = _npcsController.NpcsDic[npcId];
                Sprite icon = npc.Icon;
                string nameNpc = npc.NpcName;
                if (npc.CanGift())
                {
                    FeelNpc feelNpc = FeelNpc.Normal;
                    string favId = npc.FavoriteItemSetId;
                    if (_npcsController.FavoriteItemsDic.ContainsKey(favId))
                    {
                        FavoriteItems_Template favoriteItems_Template = _npcsController.FavoriteItemsDic[favId];
                        Dictionary<string, DialogueFavoriteItem> ItemLikeId = new Dictionary<string, DialogueFavoriteItem>();
                        Dictionary<string, DialogueFavoriteItem> ItemUnlikeId = new Dictionary<string, DialogueFavoriteItem>();
                        Dictionary<string, DialogueFavoriteItem> ItemExceptId = new Dictionary<string, DialogueFavoriteItem>();
                        ItemLikeId = favoriteItems_Template.ItemLikeId;
                        ItemUnlikeId = favoriteItems_Template.ItemUnLikeId;
                        ItemExceptId = favoriteItems_Template.ItemExceptId;

                        if (ItemLikeId.ContainsKey(itemId))
                        {
                            //like
                            npc.IncreaseRelationship(INST_VALUE_FAVORITE_LIKE);
                            feelNpc = FeelNpc.Like;
                        }
                        else if (ItemUnlikeId.ContainsKey(itemId))
                        {
                            //unlike
                            npc.DecreaseRelationship(INST_VALUE_FAVORITE_UnLIKE);
                            feelNpc = FeelNpc.Unlike;
                        }
                        else if (ItemExceptId.ContainsKey(itemId))
                        {
                            //except
                            npc.IncreaseRelationship(INST_VALUE_FAVORITE_EXCEPT);
                            feelNpc = FeelNpc.Except;
                        }
                        else
                        {
                            //normal
                            npc.IncreaseRelationship(INST_VALUE_FAVORITE_NORMAL);
                        }

                    }
                    else
                    {
                        //normal
                        npc.IncreaseRelationship(INST_VALUE_FAVORITE_NORMAL);
                    }

                    npc.CountGift();

                    //notification NPC's feeling 
                    switch (feelNpc)
                    {
                        case FeelNpc.Normal:
                            _notificationController.Emotion(_normal);
                            break;
                        case FeelNpc.Like:
                            _notificationController.Emotion(_like);
                            break;
                        case FeelNpc.Unlike:
                            _notificationController.Emotion(_unlike);
                            break;
                        case FeelNpc.Except:
                            _notificationController.Emotion(_except);
                            break;
                    }

                    return true;

                }
                else
                {
                    //notification
                    _notificationController.LimitGift(icon, nameNpc);
                    return false;
                }
            }
        }
        return false;
    }
}
