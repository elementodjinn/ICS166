using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 _movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_movement.x, _movement.y).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
