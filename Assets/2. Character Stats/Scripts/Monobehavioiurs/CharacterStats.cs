using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Fields

    [SerializeField]
    public CharacterStats_SO characterDefinition_Template;
    public CharacterStats_SO characterDeginition_Current;
    public CharacterSkill characterSkill;

    #endregion

    #region Constuctors
    public CharacterStats()
    {
        
    }
    #endregion

    #region Initializations
    private void Awake()
    {
        if(characterDefinition_Template != null)
        {
            characterDeginition_Current = Instantiate(characterDefinition_Template);
        }
    }

    private void Start()
    {
        if (characterDeginition_Current.isPlayer)
        {

        }
    }
    #endregion

    

}
