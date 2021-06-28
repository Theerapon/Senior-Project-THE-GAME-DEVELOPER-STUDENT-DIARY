using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStore : MonoBehaviour
{
    [Header("Initializing Store")]
    [SerializeField] private StoreType _storeType;
    private string _targetStoreId;

    [Header("Controller")]
    private StoreContoller _storeContoller;
    private TimeManager _timeManager;

    private void Awake()
    {
        _storeContoller = StoreContoller.Instance;
        _timeManager = TimeManager.Instance;

        _targetStoreId = ConvertType.GetStoreId(_storeType);
    }
}
