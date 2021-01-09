using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public RectTransform parenPosition;
    public RectTransform canvas;
    public WordDisplay SpawnWord()
    {
        //Debug.Log(parenPosition.position);
        
        RectTransform prefab = wordPrefab.GetComponent<RectTransform>();

        //Debug.Log(canvas.anchoredPosition.x);

        Vector3 randomPosition = new Vector3(Random.Range(parenPosition.anchoredPosition.x + (prefab.sizeDelta.x / 2), parenPosition.sizeDelta.x), 
            100f, 0f);
        //Vector3 randomPosition = new Vector3(0f, 200f, 0f);

        //Debug.Log("Testing : " + parenPosition.anchoredPosition);


        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, parenPosition);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        
        return wordDisplay;
    }
}
