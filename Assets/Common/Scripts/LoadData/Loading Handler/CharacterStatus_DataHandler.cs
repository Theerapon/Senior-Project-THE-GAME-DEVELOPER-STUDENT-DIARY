using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus_DataHandler : DataHandler
{
    protected CharacterStatus_Template characterDeginition_Current;
    [SerializeField] private CharactersVM charactersVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public CharacterStatus_Template GetCharacterTemplate
    {
        get { return characterDeginition_Current; }
    }

    private void Awake()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        characterDeginition_Current = charactersVM.Interpert();
        if (!ReferenceEquals(characterDeginition_Current, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Character Status interpret completed");
        //Debug.Log(string.Format("Name {0}, Level {1}, Money {2}", 
        //    characterDeginition_Current.GetNameCharacter(),
        //    characterDeginition_Current.GetCurrentCharacterLevel(),
        //    characterDeginition_Current.GetCurrentMoney()));
    }
}
