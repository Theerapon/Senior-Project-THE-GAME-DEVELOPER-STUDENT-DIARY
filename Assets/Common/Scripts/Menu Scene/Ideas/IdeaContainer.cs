using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaContainer : MonoBehaviour
{
    [SerializeField] protected GameObject _template;

    protected virtual void CreateIdeasSlot()
    {
        
    }
    public void CreateTemplate()
    {
        _template.SetActive(true);
        ClearTmeplate();
        CreateIdeasSlot();
    }

    protected void ClearTmeplate()
    {
        int count = transform.childCount;
        for (int i = 1; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    protected void OnValidate()
    {
        if (_template == null)
        {
            _template = transform.GetChild(0).gameObject;
            _template.SetActive(false);
        }
    }
}
