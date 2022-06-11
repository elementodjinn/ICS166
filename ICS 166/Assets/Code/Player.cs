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
    private bool isDialogueActive; //NEW

    // Need to figure out how to stop animation when in dialogue (i.e. when isMoveEnabled is false)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animators = GetComponentsInChildren<Animator>();
        isMoveEnabled = true;
        isDialogueActive = false; //NEW
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
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].enabled = false;
        }
    }

    public void EnableMov()
    {
        isMoveEnabled = true;
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].enabled = true;
        }
    }

    // Call this function whenever dialogue ends to indicate
    // that dialogue is no longer being displayed
    public void DeactivatingDialogue() //NEW, called before/after EnableMov()
    {
        isDialogueActive = false;
    }

    // Call this function whenever dialogue starts to indicate
    // that dialogue is currently being displayed
    public void ActivatingDialogue() //NEW, called before/after DisableMov()
    {
        isDialogueActive = true;
    }

    // checks whether dialogue is currently running
    public bool IsDialogueRunning() //NEW
    {
        return isDialogueActive;
    }
}
