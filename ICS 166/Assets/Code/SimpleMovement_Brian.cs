using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement_Brian: MonoBehaviour
{

    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody2D;
    public float upSpeed;
    public float downSpeed;
    public float leftSpeed;
    public float rightSpeed;
    public string npcTag;
    private Vector2 upVelocityVec;
    private Vector2 downVelocityVec;
    private Vector2 leftVelocityVec;
    private Vector2 rightVelocityVec;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
        upVelocityVec = new Vector2(0.0f, upSpeed);
        downVelocityVec = new Vector2(0.0f, -downSpeed);
        leftVelocityVec = new Vector2(-leftSpeed, 0.0f);
        rightVelocityVec = new Vector2(rightSpeed, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            thisRigidbody2D.MovePosition(thisRigidbody2D.position + upVelocityVec * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            thisRigidbody2D.MovePosition(thisRigidbody2D.position + leftVelocityVec * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            thisRigidbody2D.MovePosition(thisRigidbody2D.position + downVelocityVec * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            thisRigidbody2D.MovePosition(thisRigidbody2D.position + rightVelocityVec * Time.fixedDeltaTime);
        }
    }

    // Can be removed from this file and made as a separate file
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == npcTag)
        {
            // Display prompt to press key to start character interaction
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Remove the prompt that has been displayed
    }

    void DisableMovement()
    {
        GetComponent<Rigidbody2D>();
        upVelocityVec = new Vector2(0.0f, 0.0f);
        downVelocityVec = new Vector2(0.0f, 0.0f);
        leftVelocityVec = new Vector2(0.0f, 0.0f);
        rightVelocityVec = new Vector2(0.0f, 0.0f);
    }

    void EnableMovement()
    {
        GetComponent<Rigidbody2D>();
        upVelocityVec = new Vector2(0.0f, upSpeed);
        downVelocityVec = new Vector2(0.0f, -downSpeed);
        leftVelocityVec = new Vector2(-leftSpeed, 0.0f);
        rightVelocityVec = new Vector2(rightSpeed, 0.0f);
    }
}
