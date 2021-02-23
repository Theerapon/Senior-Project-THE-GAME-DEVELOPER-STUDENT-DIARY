using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New database", menuName = "Database/Course Database/New database", order = 1)]
public class CourseDatabase : Database_SO
{
	[SerializeField] Course_SO[] course_SOs;

	public Course_SO GetItemReference(string courseID)
	{
		foreach (Course_SO course in course_SOs)
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

	protected override void LoadItems()
	{
		course_SOs = FindAssetsByType<Course_SO>("Assets/Common/Resources/Courses");
	}
}
