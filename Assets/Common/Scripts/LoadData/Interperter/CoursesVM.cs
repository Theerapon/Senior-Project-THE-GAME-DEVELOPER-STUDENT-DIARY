using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursesVM : MonoBehaviour
{
    #region Types
    private const string INST_SET_all = "all";
    private const string INST_SET_beginner = "beginner";
    private const string INST_SET_intermediate = "intermediate";
    private const string INST_SET_expert = "expert";
    #endregion

    #region Tags
    private const string INST_SET_NONE = "none";
    private const string INST_SET_MATH = "math";
    private const string INST_SET_PROGRAMMING = "programming";
    private const string INST_SET_ENGINE = "engine";
    private const string INST_SET_AI = "ai";
    private const string INST_SET_NETWORK = "network";
    private const string INST_SET_ART = "art";
    private const string INST_SET_DESIGN = "design";
    private const string INST_SET_TESTING = "testing";
    private const string INST_SET_SOUND = "sound";
    #endregion

    private const string INST_SET_courseID = "courseID";
    private const string INST_SET_courseName = "courseName";
    private const string INST_SET_courseAuthor = "courseAuthor";
    private const string INST_SET_courseDescription = "courseDescription";
    private const string INST_SET_courseIcon = "courseIcon";
    private const string INST_SET_courseRecommend = "courseRecommend";
    private const string INST_SET_coursePrice = "coursePrice";
    private const string INST_SET_courseSeccondTimeUsed = "courseSeccondTimeUsed";
    private const string INST_SET_courseEnergyUsed = "courseEnergyUsed";
    private const string INST_SET_courseMotivationUsed = "courseMotivationUsed";

    private const string INST_SET_mathExp = "mathExp";
    private const string INST_SET_programmingExp = "programmingExp";
    private const string INST_SET_engineExp = "engineExp";
    private const string INST_SET_aiExp = "aiExp";
    private const string INST_SET_networkExp = "networkExp";
    private const string INST_SET_designExp = "designExp";
    private const string INST_SET_artExp = "artExp";
    private const string INST_SET_soundExp = "soundExp";
    private const string INST_SET_testingExp = "testingExp";

    private const string INST_SET_codingStatus = "codingStatus";
    private const string INST_SET_designStatus = "designStatus";
    private const string INST_SET_testingStatus = "testingStatus";
    private const string INST_SET_artStatus = "artStatus";
    private const string INST_SET_soundStatus = "soundStatus";

    private const string INST_SET_expPlayer = "expPlayer";

    private const string INST_SET_createTag = "createTag";

    private Courses_Loading coursesLoading;

    private void Start()
    {
        coursesLoading = Courses_Loading.instance;
    }

    public Dictionary<string, Course> Interpert()
    {
        if (!ReferenceEquals(coursesLoading, null))
        {
            Dictionary<string, Course> courses = new Dictionary<string, Course>();

            foreach (KeyValuePair<string, string> line in coursesLoading.textLists)
            {
                Course course = null;
                string key = line.Key;
                string value = line.Value;

                course = new Course(CreateTemplate(value));

                if (!ReferenceEquals(course, null))
                {
                    courses.Add(key, course);
                }
            }
            if (!ReferenceEquals(courses, null))
            {
                return courses;
            }
        }

        return null;

    }

    private Course_Template CreateTemplate(string line)
    {
        string course_id = "";
        string course_name = "";
        string course_author = "";
        string course_description = "";
        Sprite course_icon = null;
        LevelRecommended recommended = LevelRecommended.All;
        int course_price = 0;
        int course_seccond_time = 0;
        int course_energy_consumed = 0;
        int course_motivation_consumed = 0;

        int math_exp = 0;
        int programming_exp = 0;
        int engine_exp = 0;
        int network_exp = 0;
        int ai_exp = 0;
        int design_exp = 0;
        int art_exp = 0;
        int sound_exp = 0;
        int testing_exp = 0;

        int coding_status = 0;
        int desing_status = 0;
        int testing_status = 0;
        int art_status = 0;
        int sound_status = 0;

        int player_exp = 0;
        List<CourseTag> couse_tags = new List<CourseTag>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_courseID:
                    course_id = entries[++i];
                    break;
                case INST_SET_courseName:
                    course_name = entries[++i];
                    break;
                case INST_SET_courseAuthor:
                    course_author = entries[++i];
                    break;
                case INST_SET_courseDescription:
                    course_description = entries[++i];
                    break;
                case INST_SET_courseIcon:
                    course_icon = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_courseRecommend:
                    recommended = GetRecommenedType(entries[++i]);
                    break;
                case INST_SET_coursePrice:
                    course_price = int.Parse(entries[++i]);
                    break;
                case INST_SET_courseSeccondTimeUsed:
                    course_seccond_time = int.Parse(entries[++i]);
                    break;
                case INST_SET_courseEnergyUsed:
                    course_energy_consumed = int.Parse(entries[++i]);
                    break;
                case INST_SET_courseMotivationUsed:
                    course_motivation_consumed = int.Parse(entries[++i]);
                    break;
                case INST_SET_mathExp:
                    math_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_programmingExp:
                    programming_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_engineExp:
                    engine_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_aiExp:
                    ai_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_networkExp:
                    network_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_designExp:
                    design_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_artExp:
                    art_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_soundExp:
                    sound_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_testingExp:
                    testing_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_codingStatus:
                    coding_status = int.Parse(entries[++i]);
                    break;
                case INST_SET_designStatus:
                    desing_status = int.Parse(entries[++i]);
                    break;
                case INST_SET_testingStatus:
                    testing_status = int.Parse(entries[++i]);
                    break;
                case INST_SET_artStatus:
                    art_status = int.Parse(entries[++i]);
                    break;
                case INST_SET_soundStatus:
                    sound_status = int.Parse(entries[++i]);
                    break;
                case INST_SET_expPlayer:
                    player_exp = int.Parse(entries[++i]);
                    break;
                case INST_SET_createTag:
                    couse_tags.Add(AddCourseTag(entries[++i]));
                    break;
            }

        }

        return new Course_Template(course_id, course_name, course_author, course_description, course_price, course_seccond_time, course_energy_consumed, course_motivation_consumed,
            player_exp, math_exp, programming_exp, engine_exp, ai_exp, network_exp, design_exp, art_exp, sound_exp, testing_exp, coding_status, desing_status, art_status, testing_status, sound_status, couse_tags, recommended, course_icon);
            
    }

    private LevelRecommended GetRecommenedType(string type)
    {
        LevelRecommended temp_type = LevelRecommended.All;

        switch (type)
        {
            case INST_SET_all:
                temp_type = LevelRecommended.All;
                break;
            case INST_SET_beginner:
                temp_type = LevelRecommended.BEGINNER;
                break;
            case INST_SET_intermediate:
                temp_type = LevelRecommended.INTERMEDIATE;
                break;
            case INST_SET_expert:
                temp_type = LevelRecommended.EXPERT;
                break;
        }

        return temp_type;
    }

    private CourseTag AddCourseTag(string tag)
    {
        CourseTag courseType = CourseTag.NONE;

        switch (tag)
        {
            case INST_SET_NONE:
                courseType = CourseTag.NONE;
                break;
            case INST_SET_MATH:
                courseType = CourseTag.MATH;
                break;
            case INST_SET_PROGRAMMING:
                courseType = CourseTag.PROGRAMMING;
                break;
            case INST_SET_ENGINE:
                courseType = CourseTag.ENGINE;
                break;
            case INST_SET_AI:
                courseType = CourseTag.AI;
                break;
            case INST_SET_NETWORK:
                courseType = CourseTag.NETWORK;
                break;
            case INST_SET_ART:
                courseType = CourseTag.ART;
                break;
            case INST_SET_DESIGN:
                courseType = CourseTag.DESIGN;
                break;
            case INST_SET_TESTING:
                courseType = CourseTag.TESTING;
                break;
            case INST_SET_SOUND:
                courseType = CourseTag.SOUND;
                break;
        }

        return courseType;
    }
}
