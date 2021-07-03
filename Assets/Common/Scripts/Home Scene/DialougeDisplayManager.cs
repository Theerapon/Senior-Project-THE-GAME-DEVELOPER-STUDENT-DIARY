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

    [SerializeField] private TMP_Text _npcNameTMP;
    [SerializeField] private Image _npcImage;
    [SerializeField] private TMP_Text _description;

    private List<Dialogue> dialogues;
    private int maxDialouge;
    private int countDialouge;

    private DialoguesNPC_Template _currentDialoguesNPC_Template;
    private Sprite _currentNpcProfile;
    private string _currentNameNpc;

    private string ideasId;
    private CreateEvent condition_event;


    private void Awake()
    {
        _dialougeManager = DialougeManager.Instance;
        _switchScene = SwitchScene.Instance;
        _ideasController = IdeasController.Instance;
        dialogues = new List<Dialogue>();
        _notificationController = NotificationController.Instance;
    }

    private void Start()
    {
        _currentDialoguesNPC_Template = _dialougeManager.CurrentDialoguesNPC_Template;
        _currentNpcProfile = _dialougeManager.CurrentNpcProfile;
        _currentNameNpc = _dialougeManager.CurrentNameNpc;

        dialogues = _currentDialoguesNPC_Template.DialoguesList;
        maxDialouge = dialogues.Count;
        countDialouge = 0;
        condition_event = _currentDialoguesNPC_Template.Condition_event;
        

        _npcImage.sprite = _currentNpcProfile;
        _npcNameTMP.text = _currentNameNpc;
        NextDialouge();
    }

    public void NextDialouge()
    {
        if(countDialouge < maxDialouge)
        {
            _description.text = dialogues[countDialouge].GetTextDialogue();
            countDialouge++;
        }
        else
        {
            if(_currentDialoguesNPC_Template.Condition_event == CreateEvent.CreateIdea)
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

    private void CreateIdea(string ideaName, Sprite icon)
    {
        _notificationController.RecieveIdea(ideaName, icon);
    }

}
