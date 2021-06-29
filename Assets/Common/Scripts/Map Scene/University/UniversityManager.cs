using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseActivitySlot;

public class UniversityManager : MonoBehaviour
{
    [SerializeField] private ActivityTemplateGenerator _activityTemplateGenerator;

    private ClassActivityController _classActivityController;

    private void Awake()
    {
        _classActivityController = ClassActivityController.Instance;
    }

    private void Start()
    {
        Initializing();
    }

    private void Initializing()
    {
        Dictionary<string, ClassActivity> classActivity = new Dictionary<string, ClassActivity>();
        classActivity = _classActivityController.ClassActivitiesDic;

        foreach (KeyValuePair<string, ClassActivity> activity in classActivity)
        {
            ClassActivity copy = activity.Value;
            string activityId = activity.Key;
            string activityName = copy.Activity_name;
            Day activityDay = copy.Day;
            string activityTime = string.Format("{0}:{1:00}-{2}:{3:00} น.", copy.Start_time_hour, copy.Start_time_minute, copy.End_time_hour, copy.End_time_minute);
            float energy = copy.Energy;
            string activityType = copy.ActivityType.ToString();
            Sprite activityIcon = copy.Icon;
            bool isOpen = copy.IsOpening;
            Debug.Log("open " + isOpen);
            UniversityActivity universityActivity = new UniversityActivity(activityId, activityName, activityDay, activityTime, energy, activityType, activityIcon, isOpen);
            _activityTemplateGenerator.CreateTemplate(universityActivity);
        }
    }

    public void EnterActivity(BaseActivitySlot baseActivitySlot)
    {

    }
}
