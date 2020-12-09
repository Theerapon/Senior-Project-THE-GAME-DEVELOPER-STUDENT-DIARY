using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Field
    private static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");

    private float horizontal;
    private float vertical;
    private Vector3 moveDirection;
    #endregion


    #region Inspector
    [SerializeField]
    private float speed = 1f;

    [Header("Relations")]
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private Rigidbody rgBody = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    #endregion

    #region MonoBehaviour

    private void Awake()
    {
    }

    private void Start()
    {
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection *= (speed * Time.deltaTime);
        
        
        // movement wasd
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }

        //animation
        animator.SetBool(WALK_PROPERTY,
                         Math.Abs(moveDirection.sqrMagnitude) > Mathf.Epsilon);

        //transform position
        rgBody.MovePosition(transform.position + moveDirection);
    }

    #endregion
}
