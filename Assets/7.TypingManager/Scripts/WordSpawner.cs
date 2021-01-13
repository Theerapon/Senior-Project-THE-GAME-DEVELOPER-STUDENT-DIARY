using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public RectTransform rectCanvas;
    public RectTransform rectPanel;
    public RectTransform rectPlaying;
    public WordDisplay SpawnWord()
    {

        RectTransform prefab = wordPrefab.GetComponent<RectTransform>();

        Debug.Log(rectPlaying.anchoredPosition);

        Vector3 randomPosition = new Vector3(Random.Range(rectPlaying.sizeDelta.magnitude, rectPlaying.sizeDelta.magnitude),
            100f, 0f);

        //Debug.Log("Testing : " + parenPosition.anchoredPosition);


        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, rectPanel);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        
        return wordDisplay;
    }
}
