using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGame1RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalLeftPosition;
    [SerializeField] private GameObject originalRightPosition;
    private bool isRight = false;

    public TypingGame1RandomBox SpawnWord()
    {

        int random =  Random.Range(0, 2);
        GameObject wordObj = null;
        switch (random)
        {
            case 0:
                wordObj = Instantiate(wordPrefab, originalLeftPosition.transform.position, Quaternion.identity, rectCanvas);
                isRight = false;
                break;
            case 1:
                wordObj = Instantiate(wordPrefab, originalRightPosition.transform.position, Quaternion.identity, rectCanvas);
                isRight = true;
                break;
        }

        TypingGame1RandomBox wordDisplay = wordObj.GetComponent<TypingGame1RandomBox>();

        return wordDisplay;
    }

    public bool GetIsRight()
    {
        return isRight;
    }
}
