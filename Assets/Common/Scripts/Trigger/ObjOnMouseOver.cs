using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnMouseOver : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void OnMouseExit()
    {
        animator.SetBool("hover", false);
    }

    private void OnMouseEnter()
    {
        animator.SetBool("hover", true);
    }


}
