using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUpdateGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;


    private void CreateValue(Sprite icon, string title, string description)
    {
        GameObject copy;
        copy = Instantiate(_template, transform);
        copy.transform.GetChild(1).GetComponentInChildren<Image>().sprite = icon;
        copy.transform.GetChild(2).GetChild(0).GetComponentInChildren<TMP_Text>().text = title;
        copy.transform.GetChild(2).GetChild(1).GetComponentInChildren<TMP_Text>().text = description;

    }

    public void CreateTemplate(Sprite icon, string title, string description)
    {
        _template.SetActive(true);
        CreateValue(icon, title, description);
    }

}
