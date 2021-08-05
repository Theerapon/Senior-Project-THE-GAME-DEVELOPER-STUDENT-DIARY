using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingWordMonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalLeftPosition;
    [SerializeField] private GameObject originalRightPosition;
    private bool isRight = false;

    public BetaWordTypingMonsterBox SpawnWord()
    {
        int random = Random.Range(0, 2);
        GameObject wordObj = null;
        Vector3 position = Vector3.zero;
        switch (random)
        {
            case 0:
                position = RandomPosition(originalLeftPosition.transform.position);
                wordObj = Instantiate(wordPrefab, position, Quaternion.identity, rectCanvas);
                isRight = false;
                break;
            case 1:
                position = RandomPosition(originalRightPosition.transform.position);
                wordObj = Instantiate(wordPrefab, position, Quaternion.identity, rectCanvas);
                isRight = true;
                break;
        }

        BetaWordTypingMonsterBox wordDisplay = wordObj.GetComponent<BetaWordTypingMonsterBox>();

        return wordDisplay;
    }

    public bool GetIsRight()
    {
        return isRight;
    }
    private int radius = 50;
    private Vector3 RandomPosition(Vector3 position)
    {
        Vector3 vector3 = new Vector3(Random.Range(position.x - radius, position.x + radius), 
            Random.Range(position.y - radius, position.y + radius));
        return vector3;
    }
}
