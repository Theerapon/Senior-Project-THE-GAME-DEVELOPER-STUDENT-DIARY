using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TagGenerated : MonoBehaviour
{
    private void Start()
    {
        GameObject tagTemplate = transform.GetChild(0).gameObject;
        GameObject copy;
        for (int i = 0; i < 5; i++)
        {
            copy = Instantiate(tagTemplate, transform);
            copy.transform.GetComponent<Image>().sprite = null; //image
            copy.transform.GetChild(0).GetComponent<TMP_Text>().text = "Math";
        }
        Destroy(tagTemplate);
    }
}
