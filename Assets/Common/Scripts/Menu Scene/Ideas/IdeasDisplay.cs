using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasDisplay : MonoBehaviour
{
    
    [SerializeField] private GoalIdeaContainer goalIdeaContainer;

    void Start()
    {
        goalIdeaContainer.CreateTemplate();
    }

}
