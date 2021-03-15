using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordBox : MonoBehaviour
{
    [SerializeField] protected TMP_Text tmp_Text;

    public virtual void SetWord(string word)
    {
        if(tmp_Text != null)
            tmp_Text.text = word;
    }

    public virtual void RemoveLetter()
    {
        if (tmp_Text != null)
        {
            tmp_Text.text = tmp_Text.text.Remove(0, 1);
            tmp_Text.color = Color.red;
        }
    }

    public virtual void RemoveWord()
    {
        Destroy(gameObject);
    }
}
