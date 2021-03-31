using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    [Header("Title")]
    [SerializeField] TMP_Text text;
    [SerializeField] Color text_color_highlight;

    private Color normal = new Color(1, 1, 1, 1f);

    public void Highlight()
    {
        text.color = text_color_highlight;
    }

    public void Normal()
    {
        text.color = normal;
    }
}
