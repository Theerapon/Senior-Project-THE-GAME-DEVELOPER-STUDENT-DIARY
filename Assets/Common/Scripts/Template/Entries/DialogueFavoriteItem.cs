using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFavoriteItem : MonoBehaviour
{
    private string itemId;
    private string dialogue;
    private Feel feel;

    public string ItemId { get => itemId; }
    public string Dialogue { get => dialogue; }
    public Feel Feel { get => feel; }

    public DialogueFavoriteItem(string itemId, string dialogue, Feel feel)
    {
        this.itemId = itemId;
        this.dialogue = dialogue;
        this.feel = feel;
    }
}
