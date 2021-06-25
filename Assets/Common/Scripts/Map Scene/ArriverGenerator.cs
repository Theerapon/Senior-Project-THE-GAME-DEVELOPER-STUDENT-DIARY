using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlaceEntry;

public class ArriverGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;


    private void CreateValue(Dictionary<string, Arriver> arrivers)
    {
        GameObject copy;
        foreach(KeyValuePair<string, Arriver> arriver in arrivers)
        {
            copy = Instantiate(_template, transform);
            if(arriver.Value.arriverIcon != null)
            {
                copy.GetComponentInChildren<Image>().sprite = arriver.Value.arriverIcon;
            }
            else
            {
                copy.GetComponentInChildren<Image>().sprite = null;
            }
        }
    }

    public void CreateTemplate(Dictionary<string, Arriver> arrivers)
    {
        _template.SetActive(true);
        if(transform.childCount > 0)
        {
            ClearTmeplate();
        }

        if(arrivers.Count > 0)
        {
            CreateValue(arrivers);
        }
        
    }

    public void ClearTmeplate()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
