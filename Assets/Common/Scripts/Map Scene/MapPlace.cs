using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlace : MonoBehaviour
{
    [SerializeField] private Place place;
    private string placeId;
    private PlacesController placesController;
    private SwitchScene switchScene;
    private void Awake()
    {
        placesController = PlacesController.Instance;
        switchScene = SwitchScene.Instance;
        placeId = ConvertType.GetPlaceId(place);
    }


    public void OnClick()
    {
        if(place == Place.Home)
        {
            SwitchScene.Instance.DispleyMap(false);
        }
        else
        {
            if (!placeId.Equals(string.Empty))
            {
                
                if (placesController.PlacesDic.ContainsKey(placeId))
                {
                    OnClickSwitchScene scene = placesController.PlacesDic[placeId].SwitchScene;
                    switch (scene)
                    {
                        case OnClickSwitchScene.ClothingScene:
                            switchScene.DisplayPlaceClothing(true);
                            break;
                        case OnClickSwitchScene.FoodScene:
                            switchScene.DisplayPlaceFood(true);
                            break;
                        case OnClickSwitchScene.MysticScene:
                            switchScene.DisplayPlaceMystic(true);
                            break;
                        case OnClickSwitchScene.ParkScene:
                            switchScene.DisplayPlacePark(true);
                            break;
                        case OnClickSwitchScene.SellScene:
                            switchScene.DisplayPlaceMaterial(true);
                            break;
                        case OnClickSwitchScene.TeacherScene:
                            switchScene.DisplayPlaceTeacher(true);
                            break;
                        case OnClickSwitchScene.UniversityScene:
                            switchScene.DisplayPlaceUniversity(true);
                            break;
                        default:
                            Debug.Log("default");
                            break;
                    }
                }
            }

            
        }
    }
}
