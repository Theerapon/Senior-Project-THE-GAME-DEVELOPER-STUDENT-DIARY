using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("WiatToDestroy");
    }
    IEnumerator WiatToDestroy()
    {
        yield return new WaitForSecondsRealtime(3.6f);
        OnDestroy();
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
