using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursesController : Manager<CoursesController>
{
    private Courses_DataHandler _courses_DataHandler;

    private Dictionary<string, Course> _allCourses;
    private Dictionary<string, Course> _myCourses;

    public Dictionary<string, Course> AllCourses { get => _allCourses; }
    public Dictionary<string, Course> MyCourses { get => _myCourses; }

    protected override void Awake()
    {
        base.Awake();
        _allCourses = new Dictionary<string, Course>();
        _myCourses = new Dictionary<string, Course>();
        _courses_DataHandler = FindObjectOfType<Courses_DataHandler>();
        int i = 0;
        if (!ReferenceEquals(_courses_DataHandler, null))
        {
            foreach (KeyValuePair<string, Course_Template> course in _courses_DataHandler.GetCourseDic)
            {
                _allCourses.Add(course.Key, new Course(course.Value));
            }
            Debug.Log("wait implementation for load save data");
        }

    }



    public void BuyCourse(string id)
    {
        if (_allCourses.ContainsKey(id) && !_myCourses.ContainsKey(id))
        {
            _myCourses.Add(id, new Course(_allCourses[id].Definition));
            _myCourses[id].BuyCourse();
            _allCourses.Remove(id);
        }
    }

    public void LearnCourse(string id)
    {
        if (_myCourses.ContainsKey(id))
        {
            Debug.Log(_myCourses[id].CourseName);
        }
        
    }
}
