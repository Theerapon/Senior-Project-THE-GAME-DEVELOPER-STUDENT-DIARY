using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGame2MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    private bool isRight = false;
    private Vector3 normalizeDirection;

    public TypingGame2MonsterBox SpawnWord(Vector3 originalPosition, Vector3 normalizeDirection, int isRight)
    {

        GameObject wordObj = Instantiate(wordPrefab, originalPosition, Quaternion.identity, rectCanvas);

        this.isRight = isRight != 0;
        this.normalizeDirection = normalizeDirection;

        TypingGame2MonsterBox wordDisplay = wordObj.GetComponent<TypingGame2MonsterBox>();

        return wordDisplay;
    }

    public bool GetIsRight()
    {
        return isRight;
    }
    public Vector3 GetNormalizeDirection()
    {
        return normalizeDirection;
    }
}
