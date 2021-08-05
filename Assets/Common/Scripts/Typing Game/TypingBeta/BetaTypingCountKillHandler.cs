using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetaTypingCountKillHandler : MonoBehaviour
{
    private List<Image> countSkillImage;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private BetaTypingPlayerManager playerManager;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color disableColor;

    private void Awake()
    {
        countSkillImage = new List<Image>();
    }

    private void Start()
    {
        playerManager.OnBetaTypingPlayerUpdate.AddListener(OnBetaTypingPlayerUpdateHandler);
        if (rectTransform != null)
        {
            rectTransform.GetComponentsInChildren(includeInactive: true, result: countSkillImage);
        }
        SetCountSkillImage();
    }

    private void OnBetaTypingPlayerUpdateHandler()
    {
        SetCountSkillImage();
    }

    private void SetCountSkillImage()
    {
        int count = playerManager.CountMonsterKilledToUltimateSkill;
        for (int i = 0; i < countSkillImage.Count; i++)
        {
            if (i < count)
            {
                countSkillImage[i].color = normalColor;
            }
            else
            {
                countSkillImage[i].color = disableColor;
            }
        }
    }
}
