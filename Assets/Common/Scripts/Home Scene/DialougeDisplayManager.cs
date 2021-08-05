using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeDisplayManager : MonoBehaviour
{
    private NotificationController _notificationController;
    private DialougeManager _dialougeManager;
    private SwitchScene _switchScene;
    private IdeasController _ideasController;
    private GameManager _gameManager;

    [SerializeField] private TMP_Text _npcNameTMP;
    [SerializeField] private Image _npcImage;
    [SerializeField] private TMP_Text _description;

    private List<Dialogue> dialogues;
    private int maxDialouge;
    private int countDialouge;

    private DialoguesNPC_Template _currentDialoguesNPC_Template;
    private ProjectDialogue_Template _projectDialogue_Template;
    private Sprite _currentNpcProfile;
    private string _currentNameNpc;

    private bool isProjectDailogue = false;

    private string ideasId;
    private CreateEvent condition_event;


    private void Awake()
    {
        _dialougeManager = DialougeManager.Instance;
        _switchScene = SwitchScene.Instance;
        _ideasController = IdeasController.Instance;
        dialogues = new List<Dialogue>();
        _notificationController = NotificationController.Instance;
        _gameManager = GameManager.Instance;

        if(!ReferenceEquals(_gameManager, null))
        {
            _gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        }
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.DIALOUGE && previous == GameManager.GameState.MEETING_PROJECT)
        {
            isProjectDailogue = true;
            _projectDialogue_Template = _dialougeManager.ProjectDialogue_Template;
            _currentNpcProfile = _dialougeManager.CurrentNpcProfile;
            _currentNameNpc = _dialougeManager.CurrentNameNpc;
            dialogues = _projectDialogue_Template.Dialogues;
            maxDialouge = dialogues.Count;
            countDialouge = 0;
            condition_event = CreateEvent.Null;
            _npcImage.sprite = _currentNpcProfile;
            _npcNameTMP.text = _currentNameNpc;
        }
        else if (current == GameManager.GameState.DIALOUGE && previous == GameManager.GameState.PLACE)
        {
            isProjectDailogue = false; 
            _currentDialoguesNPC_Template = _dialougeManager.CurrentDialoguesNPC_Template;
            _currentNpcProfile = _dialougeManager.CurrentNpcProfile;
            _currentNameNpc = _dialougeManager.CurrentNameNpc;
            dialogues = _currentDialoguesNPC_Template.DialoguesList;
            maxDialouge = dialogues.Count;
            countDialouge = 0;
            condition_event = _currentDialoguesNPC_Template.Condition_event;
            _npcImage.sprite = _currentNpcProfile;
            _npcNameTMP.text = _currentNameNpc;
        }
    }

    private void Start()
    {
        NextDialouge();
    }

    public void NextDialouge()
    {
        if (isProjectDailogue)
        {
            if (countDialouge < maxDialouge)
            {
                _description.text = dialogues[countDialouge].GetTextDialogue();
                countDialouge++;
            }
            else
            {
                _switchScene.DisplayDialouge(false);
            }
        }
        else
        {
            if (countDialouge < maxDialouge)
            {
                _description.text = dialogues[countDialouge].GetTextDialogue();
                countDialouge++;
            }
            else
            {
                if (_currentDialoguesNPC_Template.Condition_event == CreateEvent.CreateIdea)
                {
                    ideasId = _currentDialoguesNPC_Template.IdeaId;
                    if (_ideasController.ReceiveIdea(ideasId))
                    {
                        string ideaName = _ideasController.Ideas_DataHandler.GetIdeasDic[ideasId].IdeaName;
                        Sprite ideaIcon = _ideasController.Ideas_DataHandler.GetIdeasDic[ideasId].Icon;
                        CreateIdea(ideaName, ideaIcon);
                    }
                }

                _switchScene.DisplayDialouge(false);
            }
        }

        
    }

    private void CreateIdea(string ideaName, Sprite icon)
    {
        _notificationController.RecieveIdea(ideaName, icon);
    }

}
