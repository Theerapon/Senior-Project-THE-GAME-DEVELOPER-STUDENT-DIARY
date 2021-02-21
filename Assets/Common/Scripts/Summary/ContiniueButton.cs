using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContiniueButton : MonoBehaviour
{

    public void OnContiniue()
    {
        gameObject.SetActive(false);
        TimeManager.Instance.ContiniueGameInSummaryScene();
    }
}
