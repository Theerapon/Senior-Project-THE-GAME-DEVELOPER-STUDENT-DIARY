using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTypingMonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    private bool isRight = false;
    private Vector3 normalizeDirection;

    public AlphaTypingMonsterBox SpawnWord(Vector3 originalPosition, Vector3 normalizeDirection, int isRight)
    {

        GameObject wordObj = Instantiate(wordPrefab, originalPosition, Quaternion.identity, rectCanvas);

        this.isRight = isRight != 0;
        this.normalizeDirection = normalizeDirection;

        AlphaTypingMonsterBox wordDisplay = wordObj.GetComponent<AlphaTypingMonsterBox>();

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
