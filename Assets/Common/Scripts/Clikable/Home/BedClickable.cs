
using UnityEngine;

public class BedClickable : MonoBehaviour, IClickable
{
    [SerializeField] MenuController menuController;

    public void OnClick()
    {
        menuController.OpenHomeAction(GameManager.GameScene.Home_BED);
    }


}
