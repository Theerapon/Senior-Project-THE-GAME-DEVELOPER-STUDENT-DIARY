using UnityEngine;

public class WorkTypingMainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalPosition;
    
    public WorkTypingMainBox SpawnWord()
    {

        GameObject wordObj = Instantiate(wordPrefab, originalPosition.transform.position, Quaternion.identity, rectCanvas);

        WorkTypingMainBox wordDisplay = wordObj.GetComponent<WorkTypingMainBox>();
        
        return wordDisplay;
    }
}
