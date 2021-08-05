using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    public void CreateTemplate(Sprite icon)
    {
        GameObject copy;
        copy = Instantiate(_template, transform);
        copy.GetComponentInChildren<Image>().sprite = icon;
    }
}
