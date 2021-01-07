using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProjectDisplay : MonoBehaviour
{
    public static ProjectDisplay instance;
    [SerializeField] private Projects projects;
    [SerializeField] private GameObject ProjectDisplayHolder;
    [SerializeField] private TMP_Text textCoding;
    [SerializeField] private TMP_Text textDesign;
    [SerializeField] private TMP_Text textTesting;
    [SerializeField] private TMP_Text textArt;
    [SerializeField] private TMP_Text textAudio;
    [SerializeField] private TMP_Text textBug;
    [SerializeField] private TMP_Text textNameProject;
    [SerializeField] private Image imageFillProject;
    void Start()
    {
        instance = this;
        SetDisplayProject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DisplayProject();
        }
    }

    private void DisplayProject()
    {
        if (ProjectDisplayHolder.activeSelf == true)
        {
            ProjectDisplayHolder.SetActive(false);
        }
        else
        {
            SetDisplayProject();
            ProjectDisplayHolder.SetActive(true);
        }
    }

    private void SetDisplayProject()
    {
        textCoding.text = projects.GetCodingQuality().ToString();
        textDesign.text = projects.GetDesignQuality().ToString();
        textTesting.text = projects.GetTestingQuality().ToString();
        textArt.text = projects.GetArtQuality().ToString();
        textAudio.text = projects.GetAudioQuality().ToString();
        textBug.text = projects.GetBugValue().ToString();
        textNameProject.text = projects.GetNameProject().ToString(); //wait for name project phase
        imageFillProject.fillAmount = CalculateFillAmountProject(projects.GetCurrentXpProject());
    }

    private float CalculateFillAmountProject(int xp)
    {
        return (float) xp / projects.project_Current.GetRequireXpProject(0);
    }
}
