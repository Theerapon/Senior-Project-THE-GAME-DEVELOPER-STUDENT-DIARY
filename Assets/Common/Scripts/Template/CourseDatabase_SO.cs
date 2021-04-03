using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New database", menuName = "Database/Course Database/New database", order = 1)]
public class CourseDatabase_SO : MonoBehaviour
{
	[SerializeField] private Course_SO[] course_SoLists;

	public Course_SO GetItemReference(string courseID)
	{
		foreach (Course_SO course in course_SoLists)
		{
			if (course.ID == courseID)
			{
				return course;
			}
		}
		return null;
	}

	public Course_SO GetItemCopy(string courseID)
	{
		Course_SO course = GetItemReference(courseID);
		if (course != null)
		{
			return course.GetCopy();
		}
		else
		{
			return null;
		}
	}


	public Course_SO[] GetCourses()
    {
		return course_SoLists;
    }
	public void CourseLoadItems()
    {
		//LoadItems();
    }
}
