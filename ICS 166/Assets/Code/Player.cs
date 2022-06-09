using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;
    private Animator[] animators;
    private bool isMoving;
    private bool isMoveEnabled;

    // Need to figure out how to stop animation when in dialogue (i.e. when isMoveEnabled is false)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animators = GetComponentsInChildren<Animator>();
        isMoveEnabled = true;
    }
    // Update is called once per frame

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        if (isMoveEnabled)
        {
            Movement();
            SwitchAnimation();
        }
    }

    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(inputX, inputY);
        isMoving = movementInput != Vector2.zero;
        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //    inputX = inputX * 0.5f;
        //    inputY = inputY * 0.5f;
        //}
        inputX = inputX * 0.5f;
        inputY = inputY * 0.5f;
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime);
    }

    private void SwitchAnimation()
    {
        foreach (var anim in animators)
        {
            anim.SetBool("isMoving", isMoving);
            if (isMoving)
            {
                anim.SetFloat("InputX", inputX);
                anim.SetFloat("InputY", inputY);
            }
        }
    }

    public void DisableMov()
    {
        isMoveEnabled = false;
    }

    public void EnableMov()
    {
        isMoveEnabled = true;
    }

}
