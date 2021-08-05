using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTypingRandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalLeftPosition;
    [SerializeField] private GameObject originalRightPosition;
    private bool isRight = false;

    public WorkTypingRandomBox SpawnWord()
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

        WorkTypingRandomBox wordDisplay = wordObj.GetComponent<WorkTypingRandomBox>();

        return wordDisplay;
    }

    public bool GetIsRight()
    {
        return isRight;
    }
}
