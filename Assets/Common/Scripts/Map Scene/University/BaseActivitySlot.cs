using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseActivitySlot : MonoBehaviour
{
    public class UniversityActivity
    {
        private string _activityId;
        private string _activityName;
        private Day _activityDay;
        private string _activityTime;
        private float _energy;
        private string _activityType;
        private Sprite _activityIcon;
        private bool _isOpening;

        public UniversityActivity(string activityId, string activityName, Day activityDay, string activityTime, float energy, string activityType, Sprite activityIcon, bool isOpening)
        {
            _activityId = activityId;
            _activityName = activityName;
            _activityDay = activityDay;
            _activityTime = activityTime;
            _energy = energy;
            _activityType = activityType;
            _activityIcon = activityIcon;
            _isOpening = isOpening;
        }

        public string ActivityId { get => _activityId; }
        public string ActivityName { get => _activityName; }
        public Day ActivityDay { get => _activityDay; }
        public string ActivityTime { get => _activityTime; }
        public float Energy { get => _energy; }
        public string ActivityType { get => _activityType; }
        public Sprite ActivityIcon { get => _activityIcon; }
        public bool IsOpening { get => _isOpening; set => _isOpening = value; }
    }

    [SerializeField] protected GameObject _template;
    [SerializeField] protected Image _activityImage;
    [SerializeField] protected TMP_Text _activityTypeTMP;
    [SerializeField] protected TMP_Text _activityNameTMP;
    [SerializeField] protected TMP_Text _activityTimeTMP;
    [SerializeField] protected Image _activityEnergyIcon;
    [SerializeField] protected TMP_Text _activityEnergyTMP;
    [SerializeField] protected GameObject _button;

    [SerializeField] private Color enalbeColor;
    [SerializeField] private Color disableColor;

    protected UniversityActivity _universityActivity;
    public UniversityActivity ACTIVITY
    {
        get { return _universityActivity; }
        set
        {
            _universityActivity = value;
            UpdateInfo();
        }
    }

    private void UpdateInfo()
    {
        _activityImage.sprite = _universityActivity.ActivityIcon;
        _activityTypeTMP.text = _universityActivity.ActivityType;
        _activityNameTMP.text = _universityActivity.ActivityName;
        _activityTimeTMP.text = string.Format("{0} {1}", _universityActivity.ActivityDay, _universityActivity.ActivityTime);
        _activityEnergyTMP.text = string.Format("{0} หน่วย", _universityActivity.Energy);

        if (_universityActivity.IsOpening)
        {
            _activityImage.color = enalbeColor;
            ActiveButton(true);
        }
        else
        {
            _activityImage.color = disableColor;
            ActiveButton(false);
        }
    }


    protected virtual void OnValidate()
    {
        if (_template == null)
        {
            _template = this.gameObject;
        }

        if (_activityImage == null)
        {
            _activityImage = _template.transform.GetChild(2).GetComponentInChildren<Image>();
        }

        if (_activityTypeTMP == null)
        {
            _activityTypeTMP = _template.transform.GetChild(1).GetComponentInChildren<TMP_Text>();
        }

        if (_activityNameTMP == null)
        {
            _activityNameTMP = _template.transform.GetChild(3).GetComponentInChildren<TMP_Text>();
        }

        if (_activityTimeTMP == null)
        {
            _activityTimeTMP = _template.transform.GetChild(4).GetComponentInChildren<TMP_Text>();
        }

        if (_activityEnergyIcon == null)
        {
            _activityEnergyIcon = _template.transform.GetChild(5).GetChild(0).GetChild(1).GetComponentInChildren<Image>();
        }

        if (_activityEnergyTMP == null)
        {
            _activityEnergyTMP = _template.transform.GetChild(5).GetChild(0).GetChild(2).GetComponentInChildren<TMP_Text>();
        }

        if (_button == null)
        {
            _button = _template.transform.GetChild(6).GetChild(0).gameObject;
        }
    }

    private void ActiveButton(bool active)
    {
        if(_button.activeSelf != active)
        {
            _button.SetActive(active);
        }
    }
}
