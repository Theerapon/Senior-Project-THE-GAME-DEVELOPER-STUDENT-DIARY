using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavortieItems_Template : MonoBehaviour
{
    private string id = string.Empty;
    private List<DialogueFavoriteItem> itemLikeId = null;
    private List<DialogueFavoriteItem> itemUnLikeId = null;
    private List<DialogueFavoriteItem> itemExceptId = null;

    public string Id { get => id; }
    public List<DialogueFavoriteItem> ItemLikeId { get => itemLikeId; }
    public List<DialogueFavoriteItem> ItemUnLikeId { get => itemUnLikeId; }
    public List<DialogueFavoriteItem> ItemExceptId { get => itemExceptId; }

    public FavortieItems_Template(string id, List<DialogueFavoriteItem> itemLikeId, List<DialogueFavoriteItem> itemUnLikeId, List<DialogueFavoriteItem> itemExceptId)
    {
        this.id = id;
        this.itemLikeId = itemLikeId;
        this.itemUnLikeId = itemUnLikeId;
        this.itemExceptId = itemExceptId;
    }
}
