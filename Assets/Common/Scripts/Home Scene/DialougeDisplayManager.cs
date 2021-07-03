using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeDisplayManager : MonoBehaviour
{
    private DialougeManager _dialougeManager;
    private SwitchScene _switchScene;

    [SerializeField] private TMP_Text _npcNameTMP;
    [SerializeField] private Image _npcImage;
    [SerializeField] private TMP_Text _description;

    private List<Dialogue> dialogues;
    private int maxDialouge;
    private int countDialouge;

    private DialoguesNPC_Template _currentDialoguesNPC_Template;
    private Sprite _currentNpcProfile;
    private string _currentNameNpc;

    private List<string> ideasIdList;
    private CreateEvent condition_event;


    private void Awake()
    {
        _dialougeManager = DialougeManager.Instance;
        _switchScene = SwitchScene.Instance;
        dialogues = new List<Dialogue>();
        ideasIdList = new List<string>();
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
        ideasIdList = _currentDialoguesNPC_Template.IdeasIdList;

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
            _switchScene.DisplayDialouge(false);
        }
    }

}
