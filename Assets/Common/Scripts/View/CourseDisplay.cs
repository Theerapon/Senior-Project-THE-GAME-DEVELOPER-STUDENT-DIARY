using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CourseDisplay : Manager<CourseDisplay>
{
    [Header("Course Manager")]
    private CharacterStats characterStats;

    [Header("Course Generator")]
    [SerializeField] private CourseGenerated _courseGenerated; 


    [Header("Displays")]
    [SerializeField] private GameObject _allCourses;
    [SerializeField] private GameObject _collectionCourses;
    private GameObject preDisplay;

    [Header("Player")]
    [SerializeField] private TMP_Text namePlayer;
    [SerializeField] private TMP_Text moneyPlayer;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        ResetDisplay();
    }

    private void ResetDisplay()
    {
        UpdatePlayerData();
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

    private void UpdatePlayerData()
    {
        namePlayer.text = characterStats.GetNameCharacter();
        moneyPlayer.text = string.Format("{0:n0}", characterStats.GetCurrentMoney());
    }
}
