using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseID : MonoBehaviour
{
    private string ID;

    private CourseManager courseManager;

    private void Start()
    {
        courseManager = CourseManager.Instance;
    }

    public void SetID(string id)
    {
        ID = id;
    }

    public string GetID()
    {
        return ID;
    }

}
