using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportController : MonoBehaviour
{
    private const int INST_ENERGY_TRANSPORT_PER_MINUTE = 1;

    [SerializeField] private DijkstrasAlgo _dijkstrasAlgo;
    private PlayerAction _playerAction;
    private PlayerTransport _playerTransport;
    private SwitchScene _switchScene;
    private PlacesController _placesController;
    private float _energyToConsume;
    private int _totalSecond;
    private Place _targetPlace;
    private string _targetPlaceId;

    private void Awake()
    {
        _playerAction = PlayerAction.Instance;
        _playerTransport = PlayerTransport.Instance;
        _switchScene = SwitchScene.Instance;
        _placesController = PlacesController.Instance;

    }

    public int GetTotalTimeToTransport(int origin, int destination)
    {
        return _playerAction.GetTimeSecondToTransport(_dijkstrasAlgo.GetTimeToTransport(origin, destination) * 60);
    }

    public float GetEnergyToTransport(int minute)
    {
        return _playerAction.CalReduceEnergyToCunsume(minute * INST_ENERGY_TRANSPORT_PER_MINUTE);
    }

    public void Transporting(float energy, int second, Place target, string targetId)
    {
        _energyToConsume = energy;
        _totalSecond = second;
        _targetPlace = target;
        _targetPlaceId = targetId;
    }

    public void TransportFinished()
    {
        _playerAction.TakeEnergy(_energyToConsume);
        if (_targetPlace == Place.Home)
        {
            _playerTransport.BackHome();
            _switchScene.DispleyMap(false);
        }
        else
        {
            _playerTransport.Transport(_targetPlace);
            if (!_targetPlaceId.Equals(string.Empty))
            {

                if (_placesController.PlacesDic.ContainsKey(_targetPlaceId))
                {
                    OnClickSwitchScene scene = _placesController.PlacesDic[_targetPlaceId].SwitchScene;
                    switch (scene)
                    {
                        case OnClickSwitchScene.ClothingScene:
                            _switchScene.DisplayPlaceClothing(true);
                            break;
                        case OnClickSwitchScene.FoodScene:
                            _switchScene.DisplayPlaceFood(true);
                            break;
                        case OnClickSwitchScene.MysticScene:
                            _switchScene.DisplayPlaceMystic(true);
                            break;
                        case OnClickSwitchScene.ParkScene:
                            _switchScene.DisplayPlacePark(true);
                            break;
                        case OnClickSwitchScene.SellScene:
                            _switchScene.DisplayPlaceMaterial(true);
                            break;
                        case OnClickSwitchScene.TeacherScene:
                            _switchScene.DisplayPlaceTeacher(true);
                            break;
                        case OnClickSwitchScene.UniversityScene:
                            _switchScene.DisplayPlaceUniversity(true);
                            break;
                        case OnClickSwitchScene.TreasureScene:
                            Debug.Log("Treasure");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }


}
