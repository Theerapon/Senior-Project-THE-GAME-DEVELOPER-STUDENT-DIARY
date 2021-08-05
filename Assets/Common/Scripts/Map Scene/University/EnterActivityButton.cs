using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterActivityButton : MonoBehaviour
{
    private UniversityManager _universityManager;
    private BaseActivitySlot _baseActivitySlot;

    private void Awake()
    {
        _universityManager = FindObjectOfType<UniversityManager>();
        _baseActivitySlot = gameObject.GetComponentInParent<BaseActivitySlot>();
    }

    public void EnterActivity()
    {
        if(!ReferenceEquals(_universityManager, null))
        {
            _universityManager.EnterActivity(_baseActivitySlot);
        }
    }
}
