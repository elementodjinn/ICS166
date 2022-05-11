using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement_Brooke : MonoBehaviour
{
    private Rigidbody2D body;
    private float moveSpeed = 10;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);
    }
}
