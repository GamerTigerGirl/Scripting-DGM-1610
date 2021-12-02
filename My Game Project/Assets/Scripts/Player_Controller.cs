using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //Added player movement
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private float moveDirection;
    public bool OnGround = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Input player movement
        moveDirection = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        //Added Jump Button
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
}
