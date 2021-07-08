using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    private SwitchScene switchScene;
    private ProjectController projectController;
    private EndGameDialoguesController endGameDialoguesController;

    private const int INST_A = 10000;
    private const int INST_B = 8000;
    private const int INST_C = 5000;
    private const int INST_D = 1000;

    private Grade score;

    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _dialogueTMP; 

    private Sprite _bg;
    private List<string> _dialogues;

    private int countDialogue;

    private void Awake()
    {
        switchScene = SwitchScene.Instance;
        projectController = ProjectController.Instance;
        endGameDialoguesController = EndGameDialoguesController.Instance;
        _dialogues = new List<string>();
    }

    private void Start()
    {
        bool[] enterClass = projectController.GetEnterClass;
        float[] progress = projectController.GetProgress; 
        int[] score = projectController.GetScore;
        ProjectPhase projectPhase = projectController.ProjectPhase;
        
        this.score = CalScore(enterClass, progress, score, projectPhase);
        EndGameTemplate endGameTemplate = endGameDialoguesController.EndGameDialogueDic[this.score];
        _dialogues = endGameTemplate.Dialogues;
        _bg = endGameTemplate.Image;
        countDialogue = 0;
        _image.sprite = _bg;
        Next();
    }

    private void ExitToMenu()
    {
        switchScene.ExitToBootMenu(true);
    }

    private Grade CalScore(bool[] enterClass, float[] progress, int[] score, ProjectPhase projectPhase)
    {
        Grade grade = Grade.F;

        float sumProgress = 0;
        for(int i = 0; i < progress.Length; i++)
        {
            sumProgress += progress[i];
        }
        float avgProgress = sumProgress / progress.Length;

        float totalScore = score[score.Length - 1];

        int countEnterClass = 0;
        for(int j = 0; j < enterClass.Length; j++)
        {
            if (enterClass[j])
            {
                countEnterClass++;
            }
        }

        if(countEnterClass <= 3)
        {
            grade = Grade.F;
        }
        else
        {
            totalScore = totalScore * avgProgress;
            if(totalScore > INST_A)
            {
                grade = Grade.A;
            }
            else if(totalScore > INST_B)
            {
                grade = Grade.B;
            }
            else if(totalScore > INST_C)
            {
                grade = Grade.C;
            }
            else if(totalScore > INST_D)
            {
                grade = Grade.D;
            }
            else
            {
                grade = Grade.F;
            }
        }

        return grade;
    }

    public void Next()
    {
        if(countDialogue + 1 < _dialogues.Count)
        {
            _dialogueTMP.text = _dialogues[countDialogue++];
        }
        else
        {
            ExitToMenu();
        }
    }
}
