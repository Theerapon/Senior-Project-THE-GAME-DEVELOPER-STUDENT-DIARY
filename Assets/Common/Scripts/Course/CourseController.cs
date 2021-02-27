using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMain();
        }
    }

    public void BackToMain()
    {
        GameManager.Instance.CourseBackToMain();
    }
}
