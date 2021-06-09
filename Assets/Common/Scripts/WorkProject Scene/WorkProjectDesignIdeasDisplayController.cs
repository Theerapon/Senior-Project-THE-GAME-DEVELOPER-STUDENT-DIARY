using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkProjectDesignIdeasDisplayController : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private Image[] lines;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private GameObject[] ideasDisplayGameObjects;

    [Header("Highlight Text Color")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highligntColor;

    [Header("Goal")]
    [SerializeField] private WorkProjectGoalIdeaContainer goalIdeaContainer;
    [SerializeField] private WorkProjectGoalIdeaDisplay goalIdeaDisplay;

    [Header("Mechanic")]
    [SerializeField] private WorkProjectMechanicIdeaContainer mechanicIdeasContainer;
    [SerializeField] private WorkProjectMechanicIdeaDisplay mechanicIdeasDisplay;

    [Header("Theme")]
    [SerializeField] private WorkProjectThemeIdeaContainer themeIdeasContainer;
    [SerializeField] private WorkProjectThemeIdeaDisplay themeIdeasDisplay;

    [Header("Description")]
    [SerializeField] private GameObject descriptionGameObject;
    [SerializeField] private TMP_Text nameIdea;
    [SerializeField] private TMP_Text typeIdea;
    [SerializeField] private TMP_Text descriptionIdea;
    [SerializeField] private Image imageIdea;

    private ProjectController projectController;
    private CharacterStatusController characterStatusController;
    private IdeasController ideasController;

    #region Temp Question
    [Header("Question")]
    [SerializeField] private WorkProjectQuestionDisplay workProjectQuestionDisplay;
    private string projectName;
    private BaseWorkingProjectIdeaSlot goalSlot;
    private BaseWorkingProjectIdeaSlot[] mechanicSlots;
    private int countMechanicSlots;
    private BaseWorkingProjectIdeaSlot themeSlots;
    private string developerMessage;
    #endregion

    #region Dropdown Question
    private List<string> platformNameIdeas;
    private List<string> playerNameIdeas;
    #endregion

    private void Awake()
    {
        projectController = ProjectController.Instance;
        characterStatusController = CharacterStatusController.Instance;
        ideasController = IdeasController.Instance;
        platformNameIdeas = new List<string>();
        playerNameIdeas = new List<string>();

        #region Select temp
        goalSlot = new BaseWorkingProjectIdeaSlot();
        mechanicSlots = new BaseWorkingProjectIdeaSlot[2];
        for(int i = 0; i < mechanicSlots.Length; i++)
        {
            mechanicSlots[i] = new BaseWorkingProjectIdeaSlot();
        }
        themeSlots = new BaseWorkingProjectIdeaSlot();
        countMechanicSlots = 0;
        #endregion

        Initializing();
    }

    void Start()
    {
        OpenGoal();
        if (!ReferenceEquals(goalIdeaDisplay, null))
        {
            goalIdeaDisplay.OnPointEnterWorkProjectIdeaSlot.AddListener(OnPointEnterIdeaSlotHandler);
            goalIdeaDisplay.OnPointExitWorkProjectIdeaSlot.AddListener(OnPointExitIdeaSlotHandler);
            goalIdeaDisplay.OnClickWorkProjectIdeaSlot.AddListener(OnClickWorkProjectHandler);
        }
        if (!ReferenceEquals(mechanicIdeasDisplay, null))
        {
            mechanicIdeasDisplay.OnPointEnterWorkProjectIdeaSlot.AddListener(OnPointEnterIdeaSlotHandler);
            mechanicIdeasDisplay.OnPointExitWorkProjectIdeaSlot.AddListener(OnPointExitIdeaSlotHandler);
            mechanicIdeasDisplay.OnClickWorkProjectIdeaSlot.AddListener(OnClickWorkProjectHandler);
        }
        if (!ReferenceEquals(themeIdeasDisplay, null))
        {
            themeIdeasDisplay.OnPointEnterWorkProjectIdeaSlot.AddListener(OnPointEnterIdeaSlotHandler);
            themeIdeasDisplay.OnPointExitWorkProjectIdeaSlot.AddListener(OnPointExitIdeaSlotHandler);
            themeIdeasDisplay.OnClickWorkProjectIdeaSlot.AddListener(OnClickWorkProjectHandler);
        }
    }

    private void OnClickWorkProjectHandler(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        switch (baseIdeaSlot.IDEASLOT.IdeaType)
        {
            case IdeaType.Goal:
                CheckGoalSelect(baseIdeaSlot);
                break;
            case IdeaType.Mechanic:
                CheckMachanicSelect(baseIdeaSlot);
                break;
            case IdeaType.Theme:
                CheckThemeSelect(baseIdeaSlot);
                break;
        }

    }

    #region Select Mechanic
    private void CheckMachanicSelect(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        //slot 0 and slot 1 is empty add to slot 0
        if (mechanicSlots[0].IDEASLOT == null && mechanicSlots[1].IDEASLOT == null)
        {
            mechanicSlots[0] = baseIdeaSlot;
            LoopSetSelectMechanicNormal(baseIdeaSlot.IDEASLOT.Id, true);
        }
        //add new idea to slot 1 if slot 1 is empty and slot 0 is not null
        else if (mechanicSlots[0].IDEASLOT != null && mechanicSlots[1].IDEASLOT == null)
        {
            //and new idea to slot 1 if not same idea in slot 0
            if (!mechanicSlots[0].IDEASLOT.Id.Equals(baseIdeaSlot.IDEASLOT.Id))
            {
                mechanicSlots[1] = baseIdeaSlot;
                LoopSetSelectMechanicNormal(baseIdeaSlot.IDEASLOT.Id, true);
            }
            else //unselect as same idea
            {
                mechanicSlots[0] = new BaseWorkingProjectIdeaSlot();
                LoopSetSelectMechanicNormal(baseIdeaSlot.IDEASLOT.Id, false);
            }
        }
        //add new idea to slot 0 if slot 0 is empty and slot 1 is not null
        else if (mechanicSlots[0].IDEASLOT == null && mechanicSlots[1].IDEASLOT != null)
        {
            //and new idea to slot 0 if not same idea in slot 1
            if (!mechanicSlots[1].IDEASLOT.Id.Equals(baseIdeaSlot.IDEASLOT.Id))
            {
                mechanicSlots[0] = baseIdeaSlot;
                LoopSetSelectMechanicNormal(baseIdeaSlot.IDEASLOT.Id, true);
            }
            else //unselect as same idea
            {
                mechanicSlots[1] = new BaseWorkingProjectIdeaSlot();
                LoopSetSelectMechanicNormal(baseIdeaSlot.IDEASLOT.Id, false);
            }
        }
        else //slot 0 and slot 1 is not null
        {
            string mechanicFirstSlotId = mechanicSlots[0].IDEASLOT.Id;
            string mechanicSecondSlotId = mechanicSlots[1].IDEASLOT.Id;
            string baseSlotId = baseIdeaSlot.IDEASLOT.Id;

            //same idea first unselect
            if (mechanicFirstSlotId.Equals(baseSlotId))
            {
                mechanicSlots[0] = new BaseWorkingProjectIdeaSlot();
                LoopSetSelectMechanicNormal(baseSlotId, false);
            }
            else if (mechanicSecondSlotId.Equals(baseSlotId)) //same idea first unselect
            {
                mechanicSlots[1] = new BaseWorkingProjectIdeaSlot();
                LoopSetSelectMechanicNormal(baseSlotId, false);
            }
            else //select new idea and unselect past idea
            {
                if (countMechanicSlots == 0)
                {
                    mechanicSlots[0] = baseIdeaSlot;
                    LoopSetSelectMechanicSwap(baseSlotId, mechanicFirstSlotId);
                    countMechanicSlots = 1;
                }
                else
                {
                    mechanicSlots[1] = baseIdeaSlot;
                    LoopSetSelectMechanicSwap(baseSlotId, mechanicSecondSlotId);
                    countMechanicSlots = 0;
                }
            }
        }
        DisplayMechanicSelect();
    }
    private void LoopSetSelectMechanicNormal(string itemId, bool select)
    {
        int i = 0;
        foreach (BaseWorkingProjectIdeaSlot slot in mechanicIdeasDisplay.GetBaseIdeaSlots)
        {
            if (i <= 0)
            {
                i++;
                continue;
            }

            if (slot.IDEASLOT.Id.Equals(itemId))
                slot.SelecteIdea(select);
        }
    }
    private void LoopSetSelectMechanicSwap(string itemIdSelect, string itemIdUnSelect)
    {
        int i = 0;
        foreach (BaseWorkingProjectIdeaSlot slot in mechanicIdeasDisplay.GetBaseIdeaSlots)
        {
            if (i <= 0)
            {
                i++;
                continue;
            }

            if (slot.IDEASLOT.Id.Equals(itemIdSelect))
                slot.SelecteIdea(true);

            if (slot.IDEASLOT.Id.Equals(itemIdUnSelect))
                slot.SelecteIdea(false);
        }
    }
    private void DisplayMechanicSelect()
    {
        List<string> ideas = new List<string>();
        for(int i = 0; i < mechanicSlots.Length; i++)
        {
            if(mechanicSlots[i].IDEASLOT != null)
            {
                ideas.Add(mechanicSlots[i].IDEASLOT.IdeaName);
            }
        }
        workProjectQuestionDisplay.DisplayMechanic(ideas);
    }
    #endregion

    #region Select Theme
    private void CheckThemeSelect(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        //empty
        if (themeSlots.IDEASLOT == null)
        {
            themeSlots = baseIdeaSlot;
            LoopSetSelectThemeNormal(baseIdeaSlot.IDEASLOT.Id, true);
            workProjectQuestionDisplay.DisplayTheme(themeSlots.IDEASLOT.IdeaName, true);

        }
        else
        {
            string themeSlotId = themeSlots.IDEASLOT.Id;
            string baseSlotId = baseIdeaSlot.IDEASLOT.Id;
            //same idea
            if (themeSlotId.Equals(baseSlotId))
            {
                themeSlots = new BaseWorkingProjectIdeaSlot();
                LoopSetSelectThemeNormal(baseSlotId, false);
                workProjectQuestionDisplay.DisplayTheme(themeSlots.IDEASLOT.IdeaName, false);
            }
            else
            {
                themeSlots = baseIdeaSlot;
                LoopSetSelectThemeSwap(baseSlotId, themeSlotId);
                workProjectQuestionDisplay.DisplayTheme(themeSlots.IDEASLOT.IdeaName, true);
            }
        }
    }
    private void LoopSetSelectThemeNormal(string itemId, bool select)
    {
        int i = 0;
        foreach (BaseWorkingProjectIdeaSlot slot in themeIdeasDisplay.GetBaseIdeaSlots)
        {
            if (i <= 0)
            {
                i++;
                continue;
            }

            if (slot.IDEASLOT.Id.Equals(itemId))
                slot.SelecteIdea(select);
        }
    }
    private void LoopSetSelectThemeSwap(string itemIdSelect, string itemIdUnSelect)
    {
        int i = 0;
        foreach (BaseWorkingProjectIdeaSlot slot in themeIdeasDisplay.GetBaseIdeaSlots)
        {
            if (i <= 0)
            {
                i++;
                continue;
            }

            if (slot.IDEASLOT.Id.Equals(itemIdSelect))
                slot.SelecteIdea(true);

            if (slot.IDEASLOT.Id.Equals(itemIdUnSelect))
                slot.SelecteIdea(false);
        }
    }
    #endregion

    #region Select Goal
    private void CheckGoalSelect(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        //empty
        if(goalSlot.IDEASLOT == null)
        {
            goalSlot = baseIdeaSlot;
            LoopSetSelectGoalNormal(baseIdeaSlot.IDEASLOT.Id, true);
            workProjectQuestionDisplay.DisplayGoal(goalSlot.IDEASLOT.IdeaName, true);

        }
        else
        {
            string goalSlotId = goalSlot.IDEASLOT.Id;
            string baseSlotId = baseIdeaSlot.IDEASLOT.Id;
            //same idea
            if (goalSlotId.Equals(baseSlotId))
            {
                goalSlot = new BaseWorkingProjectIdeaSlot();
                LoopSetSelectGoalNormal(baseSlotId, false);
                workProjectQuestionDisplay.DisplayGoal(goalSlot.IDEASLOT.IdeaName, false);
            }
            else 
            {
                goalSlot = baseIdeaSlot;
                LoopSetSelectGoalSwap(baseSlotId, goalSlotId);
                workProjectQuestionDisplay.DisplayGoal(goalSlot.IDEASLOT.IdeaName, true);
            }
        }

    }
    private void LoopSetSelectGoalNormal(string itemId, bool select)
    {
        int i = 0;
        foreach (BaseWorkingProjectIdeaSlot slot in goalIdeaDisplay.GetBaseIdeaSlots)
        {
            if (i <= 0)
            {
                i++;
                continue;
            }

            if (slot.IDEASLOT.Id.Equals(itemId))
                slot.SelecteIdea(select);
        }
    }
    private void LoopSetSelectGoalSwap(string itemIdSelect, string itemIdUnSelect)
    {
        int i = 0;
        foreach (BaseWorkingProjectIdeaSlot slot in goalIdeaDisplay.GetBaseIdeaSlots)
        {
            if (i <= 0)
            {
                i++;
                continue;
            }

            if (slot.IDEASLOT.Id.Equals(itemIdSelect))
                slot.SelecteIdea(true);

            if (slot.IDEASLOT.Id.Equals(itemIdUnSelect))
                slot.SelecteIdea(false);
        }
    }
    #endregion


    private void OnPointExitIdeaSlotHandler(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        descriptionGameObject.SetActive(false);
    }

    private void OnPointEnterIdeaSlotHandler(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        descriptionGameObject.SetActive(true);
        if (baseIdeaSlot.IDEASLOT.Collected)
        {
            SetDescriptinoCollected(baseIdeaSlot);
        }
    }

    private void SetDescriptinoCollected(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        nameIdea.text = baseIdeaSlot.IDEASLOT.IdeaName;
        typeIdea.text = ConvertType.ConvertIdeaTypeToString(baseIdeaSlot.IDEASLOT.IdeaType);
        descriptionIdea.text = baseIdeaSlot.IDEASLOT.Description;
        imageIdea.enabled = true;
        imageIdea.sprite = baseIdeaSlot.IDEASLOT.IdeaImage;
    }


    private void Initializing()
    {
        foreach (GameObject gameObject in ideasDisplayGameObjects)
        {
            gameObject.SetActive(true);
        }
        descriptionGameObject.SetActive(false);

        goalIdeaContainer.CreateTemplate();
        mechanicIdeasContainer.CreateTemplate();
        themeIdeasContainer.CreateTemplate();
        InitializingQuestionDropdown();
    }

    private void InitializingQuestionDropdown()
    {
        foreach(KeyValuePair<string, Idea> platform in ideasController.PlatformIdeas)
        {
            platformNameIdeas.Add(platform.Value.IdeaName);
        }
        foreach (KeyValuePair<string, Idea> player in ideasController.PlayerIdeas)
        {
            playerNameIdeas.Add(player.Value.IdeaName);
        }

        workProjectQuestionDisplay.DisplayDropdown(platformNameIdeas, playerNameIdeas);
    }

    public void OpenGoal()
    {
        OnButtonClicked(0);

    }

    public void OpenMechanic()
    {
        OnButtonClicked(1);

    }

    public void OpenTheme()
    {
        OnButtonClicked(2);

    }

    public void CancelDesignDocument()
    {
        SwitchScene.Instance.DisplayWorkProjectDesign(false);
    }

    private void SetAllButtonsInteractable(int index)
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == index)
            {
                buttons[i].interactable = false;
                lines[i].enabled = true;
                texts[i].color = highligntColor;
                ideasDisplayGameObjects[i].SetActive(true);
            }
            else
            {
                buttons[i].interactable = true;
                lines[i].enabled = false;
                texts[i].color = normalColor;
                ideasDisplayGameObjects[i].SetActive(false);
            }
        }

    }

    private void OnButtonClicked(int index)
    {
        if (index == -1)
            return;

        SetAllButtonsInteractable(index);
    }
}
