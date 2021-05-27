using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus_DataHandler : Manager<CharacterStatus_DataHandler>
{
    protected CharacterStatus_Template characterDeginition_Current;
    [SerializeField] private CharactersVM charactersVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public CharacterStatus_Template GetCharacterTemplate
    {
        get { return characterDeginition_Current; }
    }

    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);

    }

    private void EventInterpretHandler()
    {
        characterDeginition_Current = charactersVM.Interpert();
        //Debug.Log("activities interpret completed");
        //Debug.Log(string.Format("Name {0}, Level {1}, Money {2}", 
        //    characterDeginition_Current.GetNameCharacter(),
        //    characterDeginition_Current.GetCurrentCharacterLevel(),
        //    characterDeginition_Current.GetCurrentMoney()));
    }
}
