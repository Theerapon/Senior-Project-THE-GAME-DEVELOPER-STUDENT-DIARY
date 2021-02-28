using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryContiniue : MonoBehaviour
{
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;
    private CharacterStats characterStats;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
    }

    public void OnContiniue()
    {
        playerAction.Sleep(playerAction.GetCalculateSleepTimeSecond(characterStats.GetSleepFullTimeSelected()));

    }
}
