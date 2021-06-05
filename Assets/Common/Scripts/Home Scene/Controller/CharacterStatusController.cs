using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusController : Manager<CharacterStatusController>
{
    private CharacterStatus_DataHandler characterStatus_DataHandler;
    private CharacterStatus characterStatus;
    public CharacterStatus CharacterStatus { get => characterStatus; }

    private void Start()
    {
        characterStatus_DataHandler = FindObjectOfType<CharacterStatus_DataHandler>();
        if (!ReferenceEquals(characterStatus_DataHandler, null))
        {
            characterStatus = new CharacterStatus(characterStatus_DataHandler.GetCharacterTemplate);
            Debug.Log("wait implementation for load save data");
        }

    }
}
