using UnityEngine;
using static BaseActivitySlot;

public class ActivityTemplateGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject _itemTemplate;

    protected virtual void CreateActivityTemplate(UniversityActivity activity)
    {
        GameObject copy;
        copy = Instantiate(_itemTemplate, transform);
        copy.GetComponent<BaseActivitySlot>().ACTIVITY = activity;

    }

    public virtual void CreateTemplate(UniversityActivity activity)
    {
        _itemTemplate.SetActive(true);
        CreateActivityTemplate(activity);
    }
}
