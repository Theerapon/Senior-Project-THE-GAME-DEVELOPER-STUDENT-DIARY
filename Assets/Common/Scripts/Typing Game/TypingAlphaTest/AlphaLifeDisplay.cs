using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaLifeDisplay : MonoBehaviour
{
    private List<Image> lifesImage;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private AlphaTypingPlayerManager playerManager;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color disableColor;

    private void Awake()
    {
        lifesImage = new List<Image>();
    }

    private void Start()
    {
        playerManager.OnAlphaTypingPlayerUpdate.AddListener(OnAlphaTypingPlayerUpdateHandler);
        if (rectTransform != null)
        {
            rectTransform.GetComponentsInChildren(includeInactive: true, result: lifesImage);
        }
        SetLifeImage();
    }

    private void OnAlphaTypingPlayerUpdateHandler()
    {
        SetLifeImage();
    }

    private void SetLifeImage()
    {
        int life = playerManager.Life;
        for (int i = 0; i < lifesImage.Count; i++)
        {
            if (i < life)
            {
                lifesImage[i].color = normalColor;
            }
            else
            {
                lifesImage[i].color = disableColor;
            }
        }
    }
}
