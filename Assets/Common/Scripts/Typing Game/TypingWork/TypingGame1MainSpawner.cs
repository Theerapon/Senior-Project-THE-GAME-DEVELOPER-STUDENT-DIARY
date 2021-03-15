using UnityEngine;

public class TypingGame1MainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalPosition;
    
    public TypingGame1MainBox SpawnWord()
    {

        GameObject wordObj = Instantiate(wordPrefab, originalPosition.transform.position, Quaternion.identity, rectCanvas);

        TypingGame1MainBox wordDisplay = wordObj.GetComponent<TypingGame1MainBox>();
        
        return wordDisplay;
    }
}
