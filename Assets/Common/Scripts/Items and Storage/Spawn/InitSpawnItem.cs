using System.Collections.Generic;
using UnityEngine;

public class InitSpawnItem : MonoBehaviour, ISpawns
{
    private ItemsVM itemsVM;

    public List<ItemPickUp_Template> itemDefinitions;

    [SerializeField] private ItemID[] itemsPool;
    public int whichToSpawn = 0;
    public int totalSpawnWeight = 0;
    public int chosen = 0;

    [Header("Item Prefab")]
    [SerializeField] private GameObject itemPrefab;
    public GameObject itemTemplate { get; set; }
    public ItemPickUp itemType { get; set; }

    protected void Start()
    {
        itemsVM = FindObjectOfType<ItemsVM>();
        itemDefinitions = new List<ItemPickUp_Template>();
        itemDefinitions.Clear();

        itemTemplate = itemPrefab;

    }

    public void CreateSpawn()
    {
        Initialized();

        foreach (ItemPickUp_Template ip in itemDefinitions)
        {
            totalSpawnWeight += ip.GetItemSpawnChanceWeight();
        }
        //Spawn with weighted possibilities

        chosen = Random.Range(0, totalSpawnWeight);

        foreach (ItemPickUp_Template ip in itemDefinitions)
        {
            whichToSpawn += ip.GetItemSpawnChanceWeight();
            if (whichToSpawn >= chosen)
            {
                GameObject item_copy = Instantiate(itemTemplate);

                itemType = item_copy.GetComponent<ItemPickUp>();
                itemType.itemDefinition = ip;
                whichToSpawn = 0;
                itemType.StoreItem();
                break;
            }
        }
        itemDefinitions.Clear();
    }

    private void Initialized()
    {
        foreach(ItemID item in itemsPool)
        {
            itemDefinitions.Add(itemsVM.Interpert(item.GetItemID()));
        }


        
    }


}
