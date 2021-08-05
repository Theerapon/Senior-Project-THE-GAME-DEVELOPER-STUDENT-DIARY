using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueUpdateGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Color color;

    private void CreateValue(string value)
    {
        GameObject copy;
        copy = Instantiate(_template, transform);
        TMP_Text TMP = copy.transform.GetComponentInChildren<TMP_Text>();
        TMP.text = value;
        TMP.color = color;
    }

    public void CreateTemplate(string value)
    {
        _template.SetActive(true);
        CreateValue(value);
    }
}
