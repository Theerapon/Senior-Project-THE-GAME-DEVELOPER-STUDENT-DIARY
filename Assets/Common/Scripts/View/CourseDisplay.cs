using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseDisplay : Manager<CourseDisplay>
{
    [Header("Course Generator")]
    [SerializeField] private CourseGenerated _courseGenerated; 


    [Header("Displays")]
    [SerializeField] private GameObject _allCourses;
    [SerializeField] private GameObject _collectionCourses;
    private GameObject preDisplay;

    private void Start()
    {
        ResetDisplay();
    }

    private void ResetDisplay()
    {
        _allCourses.SetActive(true);
        _collectionCourses.SetActive(false);
        preDisplay = _allCourses;
    }

    public void DisplayAllCourses()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE)
        {
            if (_allCourses.activeSelf == false && _allCourses != null)
            {
                CreateAllCourses();
                preDisplay.SetActive(false);
                _allCourses.SetActive(true);
                preDisplay = _allCourses;
            }
        }

    }
    public void DisplayCollections()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE)
        {
            if (_collectionCourses.activeSelf == false && _collectionCourses != null)
            {
                preDisplay.SetActive(false);
                _collectionCourses.SetActive(true);
                preDisplay = _collectionCourses;
            }
        }
    }


    private void CreateAllCourses()
    {
        _courseGenerated.CreateTemplate();
    }

}
