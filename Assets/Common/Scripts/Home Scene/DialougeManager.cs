using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : Manager<DialougeManager>
{
    private const int INST_VALUE_RELATIONSHIP = 1;

    [SerializeField] DialougeNpcTemplateController _dialougeNpcTemplateController;
    [SerializeField] NpcsController _npcsController;
    [SerializeField] PlayerAction _playerAction;

    private NotificationController _notificationController;
    private SwitchScene _switchScene;

    private DialoguesNPC_Template _currentDialoguesNPC_Template;
    private string _currentNpcId;
    private string _currentNameNpc;
    private Sprite _currentNpcProfile;

    public DialoguesNPC_Template CurrentDialoguesNPC_Template { get => _currentDialoguesNPC_Template; }
    public string CurrentNameNpc { get => _currentNameNpc; }
    public Sprite CurrentNpcProfile { get => _currentNpcProfile;}

    protected override void Awake()
    {
        base.Awake();
        _switchScene = SwitchScene.Instance;
        
    }


    public void Dialouge(string npcId, string npcName, Sprite npcProfile, Place currentPlace)
    {
        _notificationController = NotificationController.Instance;
        if (!ReferenceEquals(_dialougeNpcTemplateController.DialoguesNpcDic, null) && !ReferenceEquals(_npcsController.NpcsDic, null))
        {
            if (_npcsController.NpcsDic.ContainsKey(npcId))
            {
                Npc npc = _npcsController.NpcsDic[npcId];
                if (_npcsController.NpcsDic[npcId].CanChat())
                {
                    List<DialoguesNPC_Template> dialoguesTemp = new List<DialoguesNPC_Template>();

                    int relationship = npc.Relationship;

                    List<DialoguesNPC_Template> dialogues = new List<DialoguesNPC_Template>();
                    dialogues = _dialougeNpcTemplateController.DialoguesNpcDic[npcId];

                    for (int i = 0; i < dialogues.Count; i++)
                    {
                        int first_relationship = dialogues[i].First_relationship;
                        int end_relationship = dialogues[i].End_relationship;

                        if (relationship >= first_relationship && relationship <= end_relationship)
                        {
                            Place place = dialogues[i].Condition_place;
                            if (place == Place.Null)
                            {
                                dialoguesTemp.Add(dialogues[i]);
                            }
                            else
                            {
                                if (currentPlace == place)
                                {
                                    dialoguesTemp.Add(dialogues[i]);
                                }
                            }
                        }
                    }

                    if(dialoguesTemp.Count > 0)
                    {
                        int index = UnityEngine.Random.Range(0, dialoguesTemp.Count);
                        _currentDialoguesNPC_Template = dialoguesTemp[index];

                        _currentNpcId = npcId;
                        _currentNpcProfile = npcProfile;
                        _currentNameNpc = npcName;
                        int valueRelationship = (int)(_playerAction.GetTotalBonusCharm() * INST_VALUE_RELATIONSHIP);
                        npc.IncreaseRelationship(valueRelationship);
                        npc.CountChat();
                        _switchScene.DisplayDialouge(true);
                    }
                    else
                    {
                        _currentDialoguesNPC_Template = null;
                        _notificationController.LimitChat(npcProfile, npcName);
                    }

                    
                }
                else
                {
                    _notificationController.LimitChat(npcProfile, npcName);
                }
            }

        }

    }

}
