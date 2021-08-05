using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WordBox : MonoBehaviour
{
    [SerializeField] protected TMP_Text tmp_Text;
    [SerializeField] protected Canvas canvas;
    [SerializeField] protected Color normal;
    [SerializeField] protected Color highlight;

    public virtual void SetWord(string word)
    {
        if(tmp_Text != null)
        {
            tmp_Text.text = word;
            tmp_Text.color = normal;
        }
    }

    protected virtual void Reset()
    {
        canvas.gameObject.SetActive(true);
    }

    public virtual void RemoveLetter()
    {
        if (tmp_Text != null)
        {
            tmp_Text.text = tmp_Text.text.Remove(0, 1);
            tmp_Text.color = highlight;
        }
    }

    public virtual void RemoveWord()
    {
        if(gameObject != null)
            Destroy(gameObject);
    }

    public virtual void UpdatedOrderLayer()
    {
        canvas.sortingOrder = 10;
    }

    public virtual void TypedCompleted()
    {

    }
}
