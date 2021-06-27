using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveController : MonoBehaviour
{

    private ItemTemplateController _templateController;
    private PlayerAction _playerAction;
    private TreasureController _treasureController;
    private SwitchScene _switchScene;

    private List<SpawnItem> _currentSpawnItems;

    [Header("Item Prefab")]
    [SerializeField] private GameObject _itemPrefab;
    private GameObject _itemTemp;
    private Stack<ItemPickUp> _itemsReceive;

    [Header("Show Item Receive")]
    [SerializeField] private GameObject _receiveCanvas;

    [Header("Item Generator")]
    [SerializeField] private ItemReceiveGenerator _itemReceiveGenerator;

    private void Awake()
    {
        _templateController = ItemTemplateController.Instance;
        _treasureController = TreasureController.Instance;
        _playerAction = PlayerAction.Instance;
        _switchScene = SwitchScene.Instance;
        _itemsReceive = new Stack<ItemPickUp>();
        _currentSpawnItems = new List<SpawnItem>();

        ActiveReceiveCanvas(false);
        _itemTemp = _itemPrefab;
        
    }

    private void Start()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        _currentSpawnItems = _treasureController.SpawnItems;
        for (int i = 0; i < _currentSpawnItems.Count; i++)
        {
            string itemId = _currentSpawnItems[i].ItemId;
            float spawnChance = _currentSpawnItems[i].SpawnChance;

            //spawn chance 0 - 1
            spawnChance *= _playerAction.GetTotalBonusIncreaseDropRate();
            float rnd = Random.Range(0f, 1f);
            if(rnd <= spawnChance)
            {
                GameObject item_copy = Instantiate(_itemTemp);
                _itemsReceive.Push(item_copy.GetComponent<ItemPickUp>());
                _itemsReceive.Peek().itemDefinition = _templateController.ItemTemplateDic[itemId];
            }
        }

        ActiveReceiveCanvas(true);
        CreateTemplate();
    }

    public void CreateTemplate()
    {
        if(_itemsReceive.Count > 0)
        {
            ItemPickUp itemPickUp = _itemsReceive.Pop();
            _itemReceiveGenerator.CreateTemplate(itemPickUp.itemDefinition);
            itemPickUp.StoreItem();
        }
        else
        {
            _switchScene.DisplayStachInventory(true);
        }
    }

    private void ActiveReceiveCanvas(bool active)
    {
        if(_receiveCanvas.activeSelf != active)
        {
            _receiveCanvas.SetActive(active);
        }
    }
}
