using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 _movement;

    public bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().name == "red")//cam detect different object when touched
        {
            Debug.Log("red!");
        }
        else
        {
            Debug.Log("other");
        }
    }


    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_movement.x, _movement.y).normalized;

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
