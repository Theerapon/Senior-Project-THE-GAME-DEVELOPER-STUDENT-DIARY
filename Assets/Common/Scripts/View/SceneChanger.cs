using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    FadeToLevel();
        //}
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log("Fade Complete");
        //LoadScene
    }
}
