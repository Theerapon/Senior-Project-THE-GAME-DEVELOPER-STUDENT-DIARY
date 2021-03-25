using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns
{
    private ItemsVM itemsVM;

    public List<ItemPickUp_Template> itemDefinitions;

    [SerializeField] private Item[] itemsPool;
    public int whichToSpawn = 0;
    public int totalSpawnWeight = 0;
    public int chosen = 0;

    public Rigidbody itemSpawned { get; set; }
    public ItemPickUp itemType { get; set; }
    public Renderer itemMaterial { get; set; }

    protected void Start()
    {
        itemsVM = FindObjectOfType<ItemsVM>();
        itemDefinitions = new List<ItemPickUp_Template>();
        itemDefinitions.Clear();
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
                itemSpawned = Instantiate(ip.GetItemRigidbody(), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = ip;
                whichToSpawn = 0;
                break;
            }
        }
        itemDefinitions.Clear();
    }

    private void Initialized()
    {
        foreach(Item item in itemsPool)
        {
            itemDefinitions.Add(itemsVM.Interpert(item.GetItemID()));
        }


        
    }


}
