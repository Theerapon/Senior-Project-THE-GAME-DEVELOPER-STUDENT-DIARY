using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDialoguesController : Manager<EndGameDialoguesController>
{
    private EndGameDialogues_DataHandler endGameDialogues_DataHandler;
    private Dictionary<Grade, EndGameTemplate> _endGameDialogueDic;

    public Dictionary<Grade, EndGameTemplate> EndGameDialogueDic { get => _endGameDialogueDic; }

    protected override void Awake()
    {
        base.Awake();
        _endGameDialogueDic = new Dictionary<Grade, EndGameTemplate>();
        endGameDialogues_DataHandler = FindObjectOfType<EndGameDialogues_DataHandler>();
        if (!ReferenceEquals(endGameDialogues_DataHandler.EndGameDialogueDic, null))
        {
            foreach(KeyValuePair<Grade, EndGameTemplate> endgame in endGameDialogues_DataHandler.EndGameDialogueDic)
            {
                _endGameDialogueDic.Add(endgame.Key, endgame.Value);
            }
        }
    }
}
