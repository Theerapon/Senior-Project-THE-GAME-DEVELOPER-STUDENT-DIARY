using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IdeasDisplayController : MonoBehaviour
{
    #region Instace
    [Header("Idea Type Instace")]
    [SerializeField] private string INST_Goal = "เป้าหมาย";
    [SerializeField] private string INST_Mechanic = "กลไก";
    [SerializeField] private string INST_Theme = "ธีม";
    [SerializeField] private string INST_Default = "ไอเดีย";

    [Header("IDea Description Instace")]
    [SerializeField] private string INST_DefaultDescription = "ยังไม่ปลดล็อค";
    [SerializeField] private Sprite INST_Sprite = null; 
    #endregion

    [Header("Button")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private Image[] lines;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private GameObject[] ideasDisplayGameObjects;

    [Header("Highlight Text Color")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highligntColor;


    [Header("Goal")]
    [SerializeField] private GoalIdeaContainer goalIdeaContainer;
    [SerializeField] private GoalIdeaDisplay goalIdeaDisplay;

    [Header("Mechanic")]
    [SerializeField] private MechanicIdeasContainer mechanicIdeasContainer;
    [SerializeField] private MechanicIdeasDisplay mechanicIdeasDisplay;

    [Header("Theme")]
    [SerializeField] private ThemeIdeasContainer themeIdeasContainer;
    [SerializeField] private ThemeIdeasDisplay themeIdeasDisplay;

    [Header("Display Total Ideas")]
    [SerializeField] private TMP_Text countTMP;

    [Header("Description")]
    [SerializeField] private GameObject descriptionGameObject;
    [SerializeField] private TMP_Text nameIdea;
    [SerializeField] private TMP_Text typeIdea;
    [SerializeField] private TMP_Text descriptionIdea;
    [SerializeField] private Image imageIdea;


    private void Awake()
    {
        Initializing();
    }

    void Start()
    {
        OpenGoal();
        
        if(!ReferenceEquals(goalIdeaDisplay, null))
        {
            goalIdeaDisplay.OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotHandler);
            goalIdeaDisplay.OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotHandler);
        }
        if (!ReferenceEquals(mechanicIdeasDisplay, null))
        {
            mechanicIdeasDisplay.OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotHandler);
            mechanicIdeasDisplay.OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotHandler);
        }
        if (!ReferenceEquals(themeIdeasDisplay, null))
        {
            themeIdeasDisplay.OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotHandler);
            themeIdeasDisplay.OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotHandler);
        }
    }

    private void OnPointExitIdeaSlotHandler(BaseIdeaSlot baseIdeaSlot)
    {
        descriptionGameObject.SetActive(false);
    }

    private void OnPointEnterIdeaSlotHandler(BaseIdeaSlot baseIdeaSlot)
    {
        descriptionGameObject.SetActive(true);
        if (!baseIdeaSlot.IDEASLOT.Collected)
        {
            SetDescriptionUncollected(baseIdeaSlot);
        }
        else
        {
            SetDescriptinoCollected(baseIdeaSlot);
        }
    }

    private void SetDescriptionUncollected(BaseIdeaSlot baseIdeaSlot)
    {
        nameIdea.text = baseIdeaSlot.IDEASLOT.IdeaName;
        typeIdea.text = ConvertIdeaType(baseIdeaSlot.IDEASLOT.IdeaType);
        descriptionIdea.text = INST_DefaultDescription;
        imageIdea.sprite = INST_Sprite;
    }

    private void SetDescriptinoCollected(BaseIdeaSlot baseIdeaSlot)
    {
        nameIdea.text = baseIdeaSlot.IDEASLOT.IdeaName;
        typeIdea.text = ConvertIdeaType(baseIdeaSlot.IDEASLOT.IdeaType);
        descriptionIdea.text = baseIdeaSlot.IDEASLOT.Description;
        imageIdea.enabled = true;
        imageIdea.sprite = baseIdeaSlot.IDEASLOT.IdeaImage;
    }

    private void Initializing()
    {
        foreach(GameObject gameObject in ideasDisplayGameObjects)
        {
            gameObject.SetActive(true);
        }
        descriptionGameObject.SetActive(false);
    }

    #region Button Menu
    public void OpenGoal()
    {
        goalIdeaContainer.CreateTemplate();
        OnButtonClicked(0);
        SetAmountIdeas(goalIdeaContainer.IdeasController.AmountGoalIdeasHasCollected, goalIdeaContainer.IdeasController.GoalIdeas.Count, IdeaType.Goal);

    }

    public void OpenMechanic()
    {
        mechanicIdeasContainer.CreateTemplate();
        OnButtonClicked(1);
        SetAmountIdeas(goalIdeaContainer.IdeasController.AmountMechanicIdeasHasCollected, goalIdeaContainer.IdeasController.MechanicIdeas.Count, IdeaType.Mechanic);
    }

    public void OpenTheme()
    {
        themeIdeasContainer.CreateTemplate();
        OnButtonClicked(2);
        SetAmountIdeas(goalIdeaContainer.IdeasController.AmountThemeIdeasHasCollected, goalIdeaContainer.IdeasController.ThemeIdeas.Count, IdeaType.Theme);
    }

    #endregion
    
    private void SetAmountIdeas(int hasCollected, int totalIdeas, IdeaType ideaType)
    {
        countTMP.text = string.Format("{0} จาก {1}", hasCollected, totalIdeas);
    }

    private string ConvertIdeaType(IdeaType ideaType)
    {
        string unit = string.Empty;
        switch (ideaType)
        {
            case IdeaType.Goal:
                unit = INST_Goal;
                break;
            case IdeaType.Mechanic:
                unit = INST_Mechanic;
                break;
            case IdeaType.Theme:
                unit = INST_Theme;
                break;
            default:
                unit = INST_Default;
                break;
        }
        return unit;
    }

    private void SetAllButtonsInteractable(int index)
    {

        for(int i = 0; i < buttons.Length; i++)
        {
            if(i == index)
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
