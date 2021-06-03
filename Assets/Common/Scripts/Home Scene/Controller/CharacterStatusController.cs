using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusController : Manager<CharacterStatusController>
{
    public CharacterStatus characterStatus;

    private void Start()
    {
        if(!ReferenceEquals(CharacterStatus_DataHandler.Instance.GetCharacterTemplate, null))
        {
            characterStatus = new CharacterStatus(CharacterStatus_DataHandler.Instance.GetCharacterTemplate);
            Debug.Log("wait implementation for load save data");
        }

    }
}
