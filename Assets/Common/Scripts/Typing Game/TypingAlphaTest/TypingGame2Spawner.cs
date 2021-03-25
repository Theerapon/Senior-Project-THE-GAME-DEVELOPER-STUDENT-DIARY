using UnityEngine;

public class TypingGame2Spawner : MonoBehaviour
{
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private GameObject originalPosition;
    private bool isRight = false;

    private float halfWidth;
    private float haldHeight;

    private void Start()
    {
        halfWidth = rectCanvas.rect.width / 2;
        haldHeight = rectCanvas.rect.height / 2;
    }

    public TypingGame2Box SpawnWord()
    {


        GameObject wordObj = Instantiate(wordPrefab, originalPosition.transform.position, Quaternion.identity, rectCanvas);

        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                isRight = false;
                break;
            case 1:
                isRight = true;
                break;
        }

        TypingGame2Box wordDisplay = wordObj.GetComponent<TypingGame2Box>();

        return wordDisplay;
    }

    public bool GetIsRight()
    {
        return isRight;
    }

    public Vector3 GetGoldPosition()
    {
        Vector3 position = new Vector3();

        if (isRight)
        {
            position = new Vector3(halfWidth, Random.Range(-haldHeight, haldHeight));
        }
        else
        {
            position = new Vector3(-halfWidth, Random.Range(-haldHeight, haldHeight));
        }

        return position;
    }
}
