using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters_Handler : Manager<Characters_Handler>
{
    public CharacterStatus characterStats;
    private CharactersVM charactersVM;
    
    protected override void Awake()
    {
        base.Awake();
        characterStats = new CharacterStatus();
    }
    private void Start()
    {
        charactersVM = FindObjectOfType<CharactersVM>();
        characterStats = charactersVM.Interpert();

    }

}
