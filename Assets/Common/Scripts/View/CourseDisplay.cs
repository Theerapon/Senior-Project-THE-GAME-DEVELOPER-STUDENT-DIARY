using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CourseDisplay : Manager<CourseDisplay>
{
    public enum CourseDisplayState
    {
        SHOW,
        NOTIFICATION
    }
    public CourseDisplayState courseDisplayState;

    [Header("Course Manager")]
    private CharacterStats characterStats;

    [Header("Course Generator")]
    [SerializeField] private AllCourseGenerated _courseGenerated;
    [SerializeField] private CollectionGenerator _courseCollection;


    [Header("Displays")]
    [SerializeField] private GameObject _allCourses;
    [SerializeField] private GameObject _collectionCourses;
    private GameObject preDisplay;

    [Header("Player")]
    [SerializeField] private TMP_Text namePlayer;
    [SerializeField] private TMP_Text moneyPlayer;

    [Header("Time")]
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text date;
    private TimeManager timeManager;

    [Header("Notification")]
    [SerializeField] private PaymentDetailGenerator paymentDetailGenerator;
    [SerializeField] private GameObject bill;
    [SerializeField] private GameObject transaction;
    [SerializeField] private GameObject learn;
    [SerializeField] private GameObject energy;

    [Header("Scroll")]
    [SerializeField] private ScrollRect allCourseScroll;
    [SerializeField] private ScrollRect collectionCourseScroll;

    [Header("Transaction")]
    [SerializeField] private TMP_Text courseName;
    [SerializeField] private TMP_Text courseAuthor;
    [SerializeField] private TMP_Text courseOriginalPrice;
    [SerializeField] private TMP_Text courseDiscount;
    [SerializeField] private TMP_Text courseTotalPrice;

    private CourseManager courseManager;


    private void Start()
    {
        courseManager = CourseManager.Instance;
        characterStats = CharacterStats.Instance;
        timeManager = TimeManager.Instance;
        UpdateAllCourseIsMain();
    }

    void Update()
    {
        switch (courseDisplayState)
        {
            case CourseDisplayState.SHOW:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    BackToMain();
                }
                break;
            case CourseDisplayState.NOTIFICATION:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    CloseAll();
                }
                break;
        }

        
    }
    public void BackToMain()
    {
        GameManager.Instance.CourseBackToMain();
    }

    public void UpdateAllCourseIsMain()
    {
        UpdateTime();
        UpdatePlayerData();
        UpdateDisplayState(CourseDisplayState.SHOW);
        _allCourses.SetActive(true);
        _collectionCourses.SetActive(true);
        CreateAllCourses();
        CreateCollectionCourses();
        _allCourses.SetActive(true);
        _collectionCourses.SetActive(false);
        preDisplay = _allCourses;
    }

    public void UpdateCollectionCourseIsMain()
    {
        UpdateTime();
        UpdatePlayerData();
        UpdateDisplayState(CourseDisplayState.SHOW);
        _allCourses.SetActive(true);
        _collectionCourses.SetActive(true);
        CreateAllCourses();
        CreateCollectionCourses();
        _allCourses.SetActive(false);
        _collectionCourses.SetActive(true);
        preDisplay = _collectionCourses;
    }
    public void DisplayAllCourses()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE)
        {
            if (_allCourses.activeSelf == false && _allCourses != null)
            {
                preDisplay.SetActive(false);
                _allCourses.SetActive(true);
                preDisplay = _allCourses;
                CreateAllCourses();
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
                CreateCollectionCourses();
            }
        }
    }


    private void CreateAllCourses()
    {
        _courseGenerated.CreateTemplate();
    }

    private void CreateCollectionCourses()
    {
        _courseCollection.CreateTemplate();
    }

    private void UpdatePlayerData()
    {
        namePlayer.text = characterStats.GetNameCharacter();
        moneyPlayer.text = string.Format("{0:n0}", characterStats.GetCurrentMoney());
    }

    private void UpdateTime()
    {
        time.text = timeManager.GetOnTime();
        date.text = timeManager.GetOnDate();
    }

    public void DisplayBill(string id)
    {
        bill.SetActive(true);
        courseName.text = courseManager.courses[id].GetNameCourse();
        courseAuthor.text = courseManager.courses[id].GetNameAuthor();
        courseOriginalPrice.text = string.Format("{0:n0}", courseManager.courses[id].GetOriginalPrice());
        courseDiscount.text = string.Format("{0:n0}", courseManager.courses[id].GetDiscountPrice());
        courseTotalPrice.text = string.Format("{0:n0}", courseManager.courses[id].GetTotalPrice());
        paymentDetailGenerator.CreateTemplate(id);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
    }

    public void DisplayLearn()
    {
        learn.SetActive(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
    }

    public void CloseAll()
    {
        bill.SetActive(false);
        transaction.SetActive(false);
        learn.SetActive(false);
        energy.SetActive(false);
        UpdateDisplayState(CourseDisplayState.SHOW);
    }

    private void UpdateDisplayState(CourseDisplayState state)
    {
        courseDisplayState = state;
        switch (courseDisplayState)
        {
            case CourseDisplayState.SHOW:
                allCourseScroll.movementType = ScrollRect.MovementType.Elastic;
                collectionCourseScroll.movementType = ScrollRect.MovementType.Elastic;
                break;
            case CourseDisplayState.NOTIFICATION:
                allCourseScroll.movementType = ScrollRect.MovementType.Clamped;
                collectionCourseScroll.movementType = ScrollRect.MovementType.Clamped;
                break;
        }
    }
}
