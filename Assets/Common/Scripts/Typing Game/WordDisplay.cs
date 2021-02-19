using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text tmp_Text;

    public float fallSpeed = 9f;

    public void SetWord(string word)
    {
        tmp_Text.text = word;
    }

    public void RemoveLetter()
    {
        tmp_Text.text = tmp_Text.text.Remove(0, 1);
        tmp_Text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, fallSpeed * Time.deltaTime, 0f);
    }
}
