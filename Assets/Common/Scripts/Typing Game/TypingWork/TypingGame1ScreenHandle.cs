using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingGame1ScreenHandle : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textWordCorrect;
    [SerializeField] private TMP_Text textWordIncorrect;

    private TypingGame1Manager wordManager;

    void Start()
    {
        wordManager = TypingGame1Manager.Instance;
        wordManager.OnCheckedWordUpdate.AddListener(OnCheckedWordUpdateHandler);
        SetText();
    }
    private void OnCheckedWordUpdateHandler()
    {
        SetText();
    }

    private void SetText()
    {
        textScore.text = wordManager.GetScore().ToString();
        textWordCorrect.text = wordManager.GetWordCorrent().ToString();
        textWordIncorrect.text = wordManager.GetWordIncorrect().ToString();
    }
}
