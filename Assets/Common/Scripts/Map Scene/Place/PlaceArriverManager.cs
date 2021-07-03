using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static PlaceEntry;

public class PlaceArriverManager : MonoBehaviour
{
    [Header("Default")]
    [SerializeField] private Place place;

    [Header("Display")]
    [SerializeField] private TMP_Text _arriverName;
    [SerializeField] private Image _arriverProfile;
    [SerializeField] private GameObject _gift;
    [SerializeField] private GameObject _chat;

    [Header("Controller")]
    [SerializeField] private PlaceArriverDisplay _placeArriverDisplay;
    private PlacesController _placesController;
    private DialougeManager _dialougeManager;
    

    #region Field
    private string _placeId;
    private List<string> _residentsId;
    private string _currentArriverId = string.Empty;
    private int _currentSelectedIndex;
    private string _currentName = string.Empty;
    private Sprite _currentSprite = null;
    #endregion

    private void Awake()
    {
        _placesController = PlacesController.Instance;
        _dialougeManager = DialougeManager.Instance;
        _placeId = ConvertType.GetPlaceId(place);

        _residentsId = new List<string>();
        if (_placesController.PlacesDic.ContainsKey(_placeId))
        {
            _residentsId = _placesController.PlacesDic[_placeId].ResidentsID;
        }

        if (!ReferenceEquals(_placeArriverDisplay, null))
        {
            _placeArriverDisplay.OnPointerEnterNpcSlot.AddListener(OnPointerEnterHandler);
            _placeArriverDisplay.OnPointerExitNpcSlot.AddListener(OnPointerExitHandler);
            _placeArriverDisplay.OnPointerLeftClickNpcSlot.AddListener(OnPointerLeftClickHandler);
            _placeArriverDisplay.OnDisplayFinished.AddListener(Initizlizing);
        }

    }


    private void Initizlizing()
    {
        ActiveChatandGift(true);
        if (_placesController.PlacesDic.ContainsKey(_placeId))
        {
            for (int i = 0; i < _residentsId.Count; i++)
            {
                if (_placesController.PlacesDic[_placeId].Arrivers.ContainsKey(_residentsId[i]))
                {
                    _currentArriverId = _residentsId[i];
                    break;
                }
                else
                {
                    _currentArriverId = string.Empty;
                }
            }

            List<ArriverSlot> arriverSlots = new List<ArriverSlot>();
            arriverSlots = _placeArriverDisplay.arriverSlots;

            if (!_currentArriverId.Equals(string.Empty))
            {
                if (arriverSlots.Count > 0)
                {
                    for (int i = 0; i < arriverSlots.Count; i++)
                    {
                        if (arriverSlots[i].ARRIVER.arriverId.Equals(_currentArriverId))
                        {
                            arriverSlots[i].Selected();
                            ShowArriver(arriverSlots[i]);
                            _currentSelectedIndex = arriverSlots[i].LastIndex;
                            _currentName = arriverSlots[i].ARRIVER.arriverName;
                            _currentSprite = arriverSlots[i].ARRIVER.arriverProfilePicture;
                            break;
                        }
                    }
                }
                else
                {
                    ShowArriver();
                    _currentArriverId = string.Empty;
                    _currentSelectedIndex = -1;
                    _currentName = string.Empty;
                    _currentSprite = null;
                    ActiveChatandGift(false);
                }


            }
            else
            {
                if (arriverSlots.Count > 0)
                {
                    arriverSlots[0].Selected();
                    ShowArriver(arriverSlots[0]);
                    _currentArriverId = arriverSlots[0].ARRIVER.arriverId;
                    _currentSelectedIndex = arriverSlots[0].LastIndex;
                    _currentName = arriverSlots[0].ARRIVER.arriverName;
                    _currentSprite = arriverSlots[0].ARRIVER.arriverProfilePicture;
                }
                else
                {
                    ShowArriver();
                    _currentArriverId = string.Empty;
                    _currentSelectedIndex = -1;
                    _currentName = string.Empty;
                    _currentSprite = null;
                    ActiveChatandGift(false);
                }

            }
        }
    }

    private void OnPointerLeftClickHandler(ArriverSlot slot)
    {
        List<ArriverSlot> arriverSlots = new List<ArriverSlot>();
        arriverSlots = _placeArriverDisplay.arriverSlots;

        for (int i = 0; i < arriverSlots.Count; i++)
        {
            arriverSlots[i].Unselected();
        }

        slot.Selected();
        ShowArriver(slot);
        _currentSelectedIndex = slot.LastIndex;
        _currentArriverId = slot.ARRIVER.arriverId;
        _currentName = slot.ARRIVER.arriverName;
        _currentSprite = slot.ARRIVER.arriverProfilePicture;
    }

    private void OnPointerExitHandler(ArriverSlot slot)
    {
        ShowArriver(_placeArriverDisplay.arriverSlots[_currentSelectedIndex]);
    }

    private void OnPointerEnterHandler(ArriverSlot slot)
    {
        ShowArriver(slot);
    }

    private void ShowArriver(ArriverSlot slot)
    {
        _arriverName.text = slot.ARRIVER.arriverName;
        _arriverProfile.enabled = true;
        _arriverProfile.sprite = slot.ARRIVER.arriverProfilePicture;
    }
    private void ShowArriver()
    {
        _arriverName.text = string.Empty;
        _arriverProfile.enabled = false;
    }
    private void ActiveChatandGift(bool active)
    {

        if(_chat.activeSelf != active)
        {
            _chat.SetActive(active);
        }

        if(_gift.activeSelf != active)
        {
            _gift.SetActive(active);
        }
    }

    public void Chat()
    {
        if (!_currentArriverId.Equals(string.Empty))
        {
            _dialougeManager.Dialouge(_currentArriverId, _currentName, _currentSprite, place);
        }
        
    }

    public void Gift()
    {
        if (!_currentArriverId.Equals(string.Empty))
        {
            
        }
    }
}
