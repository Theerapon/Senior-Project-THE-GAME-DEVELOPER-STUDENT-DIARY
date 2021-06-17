using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkProjectDisplay : MonoBehaviour
{
    [Header("Instace")]
    [SerializeField] private string INST_Phase_Decision = "Decision";
    [SerializeField] private string INST_Phase_Design = "Design";
    [SerializeField] private string INST_Phase_FirstPlayable = "First Playable";
    [SerializeField] private string INST_Phase_Prototype = "Prototype";
    [SerializeField] private string INST_Phase_VerticalSlice = "Vertical Slice";
    [SerializeField] private string INST_Phase_AlphaTest = "Alpha Test";
    [SerializeField] private string INST_Phase_BetaTest = "Beta Test";
    [SerializeField] private string INST_Phase_Master = "Master";

    [Header("Instace lock")]
    [SerializeField] private string INST_Phase_Decision_Message = "ปรึกษาอาจารย์ที่ปรึกษาเพื่อปลดล็อค";
    [SerializeField] private string INST_Phase_Design_Message = "เขียนเอกสารการออกแบบเกมเพื่อปลดล็อค";


    [Header("Phase")]
    [SerializeField] private TMP_Text phaseTMP;
    [SerializeField] private TMP_Text startDateTMP;
    [SerializeField] private TMP_Text deadLineDateTMP;
    [SerializeField] private Image progressBarTMP;

    [Header("Status")]
    [SerializeField] private TMP_Text codingStatusTMP;
    [SerializeField] private TMP_Text designStatusTMP;
    [SerializeField] private TMP_Text testingStatusTMP;
    [SerializeField] private TMP_Text artStatusTMP;
    [SerializeField] private TMP_Text soundStatusTMP;
    [SerializeField] private TMP_Text bugStatusTMP;

    [Header("Lock")]
    [SerializeField] private TMP_Text lockMessageTMP;

    [Header("Design Document")]
    [SerializeField] private TMP_Text nameProjectTMP;
    [SerializeField] private TMP_Text detailMessageTMP;
    [SerializeField] private TMP_Text contextMessageTMP;

    [Header("Working")]
    [SerializeField] private TMP_Text energyWorkingTMP;
    [SerializeField] private TMP_Text efficiencyWorkingTMP;


    private ProjectController projectController;

    private void Awake()
    {
        projectController = ProjectController.Instance;
    }

    public void Initializing()
    {
        if(!projectController.ProjectIsNull)
        {
            SetTextPhase();
            SetTextStatus();
            if (projectController.HasDesigned)
            {
                SetTextDesignDocument();
            }

            ProjectPhase phase = projectController.ProjectPhase;
            if (phase == ProjectPhase.Decision || phase == ProjectPhase.Design)
            {
                SetTextLock(phase);
            }
            else
            {
                if (projectController.HasDesigned)
                {
                    SetTextDesignDocument();
                }
            }
        }

    }

    private void SetTextLock(ProjectPhase phase)
    {
        if(phase == ProjectPhase.Decision)
        {
            lockMessageTMP.text = INST_Phase_Decision_Message;
        }
        else
        {
            lockMessageTMP.text = INST_Phase_Design_Message;
        }
    }

    private void SetTextPhase()
    {
        phaseTMP.text = ConvertPhaseTypeToString(projectController.ProjectPhase);
        startDateTMP.text = projectController.StartDate;
        deadLineDateTMP.text = projectController.DeadlineDate;
        progressBarTMP.fillAmount = 0f;
    }

    private void SetTextStatus()
    {
        codingStatusTMP.text = projectController.CurrentCodingStatus.ToString();
        designStatusTMP.text = projectController.CurrentDesignStatus.ToString();
        testingStatusTMP.text = projectController.CurrentTestingStatus.ToString();
        artStatusTMP.text = projectController.CurrentArtStatus.ToString();
        soundStatusTMP.text = projectController.CurrentSoundStatus.ToString();
        bugStatusTMP.text = projectController.CurrentBugStatus.ToString();
    }

    private void SetTextDesignDocument()
    {

    }

    public void DisplayEnergy(float amount)
    {
        energyWorkingTMP.text = string.Format("{0:n0}", amount);
    }

    public void DisplayEfficiency(float amount)
    {
        efficiencyWorkingTMP.text = string.Format("{0:p2}", amount);
    }

    private string ConvertPhaseTypeToString(ProjectPhase projectPhase)
    {
        string str = INST_Phase_Decision;

        switch (projectPhase)
        {
            case ProjectPhase.Decision:
                str = INST_Phase_Decision;
                break;
            case ProjectPhase.Design:
                str = INST_Phase_Design;
                break;
            case ProjectPhase.FirstPlayable:
                str = INST_Phase_FirstPlayable;
                break;
            case ProjectPhase.Prototype:
                str = INST_Phase_Prototype;
                break;
            case ProjectPhase.VerticalSlice:
                str = INST_Phase_VerticalSlice;
                break;
            case ProjectPhase.AlphaTest:
                str = INST_Phase_AlphaTest;
                break;
            case ProjectPhase.BetaTest:
                str = INST_Phase_BetaTest;
                break;
            case ProjectPhase.Master:
                str = INST_Phase_Master;
                break;
        }

        return str;
    }
    
}

