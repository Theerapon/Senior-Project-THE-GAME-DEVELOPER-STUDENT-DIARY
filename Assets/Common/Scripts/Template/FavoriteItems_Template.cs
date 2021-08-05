using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteItems_Template : MonoBehaviour
{
    private string id = string.Empty;
    private Dictionary<string, DialogueFavoriteItem> itemLikeId = null;
    private Dictionary<string, DialogueFavoriteItem> itemUnLikeId = null;
    private Dictionary<string, DialogueFavoriteItem> itemExceptId = null;

    public string Id { get => id; }
    public Dictionary<string, DialogueFavoriteItem> ItemLikeId { get => itemLikeId; }
    public Dictionary<string, DialogueFavoriteItem> ItemUnLikeId { get => itemUnLikeId; }
    public Dictionary<string, DialogueFavoriteItem> ItemExceptId { get => itemExceptId; }

    public FavoriteItems_Template(string id, Dictionary<string, DialogueFavoriteItem> itemLikeId, Dictionary<string, DialogueFavoriteItem> itemUnLikeId, Dictionary<string, DialogueFavoriteItem> itemExceptId)
    {
        this.id = id;
        this.itemLikeId = itemLikeId;
        this.itemUnLikeId = itemUnLikeId;
        this.itemExceptId = itemExceptId;
    }
}
