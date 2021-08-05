using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseEventSlot;

public class EventSlotGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    
    public void CreateEventSlotGenerator(List<EventSlotInfo> eventSlotInfos)
    {
        GameObject copy;
        for(int i = 0; i < eventSlotInfos.Count; i++)
        {
            copy = Instantiate(_template, transform);
            copy.transform.GetComponentInChildren<BaseEventSlot>().EVENTSLOT = eventSlotInfos[i];
        }
       
    }

    public void CreateTemplate(List<EventSlotInfo> eventSlotInfos)
    {
        ClearTemplate();
        CreateEventSlotGenerator(eventSlotInfos);
    }

    private void ClearTemplate()
    {
        if(transform.childCount > 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }


}
