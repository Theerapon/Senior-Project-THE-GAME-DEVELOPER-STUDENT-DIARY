using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseGenerated : MonoBehaviour
{
    private void Start()
    {
        GameObject courseTemplate = transform.GetChild(0).gameObject;
        GameObject copy;
        for (int i = 0; i < 5; i++)
        {
            copy = Instantiate(courseTemplate, transform);
        }
        Destroy(courseTemplate);
    }
}
