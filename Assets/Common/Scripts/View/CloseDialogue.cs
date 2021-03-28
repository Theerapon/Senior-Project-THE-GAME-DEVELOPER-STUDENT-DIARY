using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialogue : MonoBehaviour
{
    [SerializeField] GameManager.GameScene areaScene;

    private void Update()
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameState.DIALOGUE)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnCloseDialogue();
        }
    }

    public void OnClick()
    {
        OnCloseDialogue();
    }

    private void OnCloseDialogue()
    {
        GameManager.Instance.CloseDialogue(areaScene);
    }

    public void OnFinishedDialogue()
    {
        GameManager.Instance.FinishedDialogue(areaScene);
    }
}
