using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagGenerated : MonoBehaviour
{
    private void Start()
    {
        GameObject tagTemplate = transform.GetChild(0).gameObject;
        GameObject copy;
        for (int i = 0; i < 5; i++)
        {
            copy = Instantiate(tagTemplate, transform);
        }
        Destroy(tagTemplate);
    }
}
