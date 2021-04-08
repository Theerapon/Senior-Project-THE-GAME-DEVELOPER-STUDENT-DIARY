using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class CourseDisplay : Manager<CourseDisplay>
{
    public enum CourseDisplayState
    {
        SHOW,
        NOTIFICATION
    }
    public CourseDisplayState courseDisplayState;

    private GameObject found_Player;
    private Characters_Handler chracter_handler;

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

    [Header("Course Canvas")]
    [SerializeField] private GameObject courseCanvas;

    private CourseManager courseManager;


    protected void Start()
    {
        courseManager = CourseManager.Instance;
        timeManager = TimeManager.Instance;
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();
        UpdateAllCourseIsMain();
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.COURSE)
        {
            DisplayCourseCanvas();
            UpdateCollectionCourseIsMain();
        }

        if (currentState == GameManager.GameState.COURSE_LEARN_ANIMATION)
        {
            DisplayCourseCanvas();
        }
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
        //GameManager.Instance.BackFromCourseToMain();
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

    public void DisplayCourseCanvas()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE)
        {
            if (courseCanvas.activeSelf == false)
            {
                courseCanvas.SetActive(true);
            }
        } else if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE_LEARN_ANIMATION)
        {
            if (courseCanvas.activeSelf == true)
            {
                courseCanvas.SetActive(false);
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
        namePlayer.text = chracter_handler.STATUS.GetNameCharacter();
        moneyPlayer.text = string.Format("{0:n0}", chracter_handler.STATUS.GetCurrentMoney());
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

    public void DisplayTransaction(bool purchaseSuccessful)
    {
        string str;
        transaction.SetActive(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
        if (purchaseSuccessful)
        {
            str = "Your purchase was completed successfully";
        }
        else
        {
            str = "Your purchase wasn't completed successfully";
        }
        transaction.transform.GetChild(0).gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = str;
    }

    public void DisplayEnergyNotEnough()
    {
        energy.SetActive(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
        string str = "Your energy wasn't enough";
        energy.transform.GetChild(0).gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = str;
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
