using UnityEngine;
using UnityEngine.UI;

public class DialogueBehavior : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color clickColor;
    private Image image;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
    }

    public void MouseEnter()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
    }

    public void MouseExit()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    public void MouseDown()
    {
        image.color = clickColor;
    }

    public void MouseUp()
    {
        image.color = startColor;
    }
}
