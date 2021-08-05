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
        CreateActivityTemplate(activity);
    }

    public void Clear()
    {
        int count = transform.childCount;
        if(count > 0)
        {
            for(int i = 0; i < count; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
