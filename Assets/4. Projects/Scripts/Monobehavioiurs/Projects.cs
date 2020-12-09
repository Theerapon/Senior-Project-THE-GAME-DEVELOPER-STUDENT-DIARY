using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projects : MonoBehaviour
{
    #region Fields

    [SerializeField]
    public Projects_SO project_Template;
    public Projects_SO project_Current;
    public CharacterStats characterStats;

    #endregion

    #region Initializations
    private void Awake()
    {
        if (project_Template != null)
        {
            project_Current = Instantiate(project_Template);
        }
    }

    private void Start()
    {
    }
    #endregion
}
