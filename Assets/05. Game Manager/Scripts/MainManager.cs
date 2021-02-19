using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : Manager<MainManager>
{
    public GameObject[] SystemPrefabs;
    List<GameObject> _instancedSystemPrefabs;

    protected override void Awake()
    {
        _instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

    }

    public void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    protected void OnDestroy()
    {
        if (_instancedSystemPrefabs == null)
            return;

        for (int i = 0; i < _instancedSystemPrefabs.Count; ++i)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }
}
