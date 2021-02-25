using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseGenerated : MonoBehaviour
{
    private void Start()
    {
        GameObject courseTemplate = transform.GetChild(0).gameObject;
        GameObject copy;
        for (int i = 0; i < 5; i++)
        {
            copy = Instantiate(courseTemplate, transform);
            copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null; //image
            copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "qqqqqqqqqqq"; //Title course
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "description"; //Description > Description text
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "aa"; //Author > Author Text
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "-All level"; //Tag > Recommended > Recommended text


        }
        Destroy(courseTemplate);
    }
}
