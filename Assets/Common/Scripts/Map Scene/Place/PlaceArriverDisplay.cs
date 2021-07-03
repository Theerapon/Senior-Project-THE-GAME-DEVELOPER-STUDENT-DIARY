using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlaceEntry;

public class PlaceArriverDisplay : MonoBehaviour
{
    public Events.EventOnPointerEnterNpcSlot OnPointerEnterNpcSlot;
    public Events.EventOnPointerExitNpcSlot OnPointerExitNpcSlot;
    public Events.EventOnPointerLeftClickNpcSlot OnPointerLeftClickNpcSlot;
    public Events.EventOnDisplayFinished OnDisplayFinished;

    [SerializeField] private ArriverAtPlaceGenerator _arriverAtPlaceGenerator;
    [SerializeField] private Place _place;
    [SerializeField] private Transform itemsParent;


    private string _placeId;
    public List<ArriverSlot> arriverSlots;

    private PlacesController _placesController;
    private GameManager _gameManager;

    private void Awake()
    {
        _placesController = PlacesController.Instance;
        _placeId = ConvertType.GetPlaceId(_place);
        _gameManager = GameManager.Instance;
        _gameManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameManager.GameState current, GameManager.GameState previous)
    {
        if (current == GameManager.GameState.PLACE && (previous == GameManager.GameState.TRANSPORTING || previous == GameManager.GameState.MAP))
        {
            Initializing();
        }
    }

    private void Initializing()
    {
        if (!ReferenceEquals(_placesController.PlacesDic, null))
        {
            if (_placesController.PlacesDic.ContainsKey(_placeId))
            {
                PlaceEntry place = _placesController.PlacesDic[_placeId];
                Dictionary<string, Arriver> arrivers = new Dictionary<string, Arriver>();
                arrivers = place.Arrivers;
                if(arrivers.Count > 0)
                {
                    _arriverAtPlaceGenerator.CreateTemplateArriverAtPlace(arrivers);

                    if (itemsParent != null)
                        itemsParent.GetComponentsInChildren(includeInactive: true, result: arriverSlots);

                    for (int index = 0; index < arriverSlots.Count; index++)
                    {
                        arriverSlots[index].OnPointerEnterNpcSlot.AddListener(OnPointerEnterNpcSlotHandler);
                        arriverSlots[index].OnPointerExitNpcSlot.AddListener(OnPointerExitNpcSlotHandler);
                        arriverSlots[index].OnPointerLeftClickNpcSlot.AddListener(OnPointerLeftClickNpcSlotHandler);
                    }
                    OnDisplayFinished?.Invoke();
                }
                
            }
        }

        
    }

    private void OnPointerLeftClickNpcSlotHandler(ArriverSlot slot)
    {
        OnPointerLeftClickNpcSlot?.Invoke(slot);
    }

    private void OnPointerExitNpcSlotHandler(ArriverSlot slot)
    {
        OnPointerExitNpcSlot?.Invoke(slot);
    }

    private void OnPointerEnterNpcSlotHandler(ArriverSlot slot)
    {
        OnPointerEnterNpcSlot?.Invoke(slot);
    }
}
