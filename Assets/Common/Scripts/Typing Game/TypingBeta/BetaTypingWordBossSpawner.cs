using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingWordBossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalPosition;

    public BetaWordBossBox SpawnWord()
    {

        GameObject wordObj = Instantiate(wordPrefab, originalPosition.transform.position, Quaternion.identity, rectCanvas);

        BetaWordBossBox wordDisplay = wordObj.GetComponent<BetaWordBossBox>();

        return wordDisplay;
    }
}
