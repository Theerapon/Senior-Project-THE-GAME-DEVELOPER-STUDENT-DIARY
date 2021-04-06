using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters_Handler : Manager<Characters_Handler>
{
    protected CharacterStatus characterStatus;
    private CharactersVM charactersVM;
    public CharacterStatus STATUS
    {
        get { return characterStatus; }
    }

    protected override void Awake()
    {
        base.Awake();
        characterStatus = new CharacterStatus();
    }
    private void Start()
    {
        charactersVM = FindObjectOfType<CharactersVM>();
        characterStatus = charactersVM.Interpert();

    }


}
