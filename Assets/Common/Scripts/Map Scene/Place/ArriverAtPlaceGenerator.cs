using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlaceEntry;

public class ArriverAtPlaceGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    private void CreateArriverAtPlace(Dictionary<string, Arriver> arrivers)
    {
        GameObject copy;
        int index = 0;
        foreach (KeyValuePair<string, Arriver> arriver in arrivers)
        {
            if (!arriver.Value.arriverId.Equals("PLAYER"))
            {
                copy = Instantiate(_template, transform);
                copy.transform.GetComponent<ArriverSlot>().ARRIVER = arriver.Value;
                copy.transform.GetComponent<ArriverSlot>().LastIndex = index;
                index++;
            }
        }
    }

    public void CreateTemplateArriverAtPlace(Dictionary<string, Arriver> arrivers)
    {
        if (transform.childCount > 0)
        {
            ClearTmeplateArriverAtPlace();
        }

        if (arrivers.Count > 0)
        {
            CreateArriverAtPlace(arrivers);
        }
    }

    public void ClearTmeplateArriverAtPlace()
    {
        int count = transform.childCount;
        for (int i = 1; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
