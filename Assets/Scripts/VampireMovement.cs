using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VampireMovement : MonoBehaviour
{

    public enum vampOptions
    {
        TOP_VAMPIRE,
        BOTTOM_VAMPIRE
    }

    public vampOptions vampSelected;

    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D thisCollider;

    private float moveSpeed = 6f;
    private float jumpPower = 25.0f;
    private bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>())
        {
            Move(); // Process Movement
            Jump(); // Process Jumping
        }
    }

    void Move()
    {
        // Switch the control scheme depending on what vampire you're controlling
        switch (vampSelected)
        {
            case vampOptions.TOP_VAMPIRE:
                // Stop horizontal movement if horizontal keys are not pressed or both are pressed
                if (!(Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D)) | (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.D)))
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D)) // Move Right
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                        sr.flipX = false;
                    }

                    if (Input.GetKey(KeyCode.A)) // Move Left
                    {
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                        sr.flipX = true;
                    }
                }
                break;
            case vampOptions.BOTTOM_VAMPIRE:
                // Stop horizontal movement if horizontal keys are not pressed or both are pressed
                if (!(Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.LeftArrow)) | (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.LeftArrow)))
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                else
                {
                    if (Input.GetKey(KeyCode.RightArrow)) // Move Right
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                        sr.flipX = false;
                    }

                    if (Input.GetKey(KeyCode.LeftArrow)) // Move Left
                    {
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                        sr.flipX = true;
                    }
                }
                break;
        }
    }

    void Jump()
    {
        // Don't allow jumping unless the vampire is touching the ground or an interactable object
        if (!jumped && (thisCollider.IsTouchingLayers(LayerMask.GetMask("Border")) || thisCollider.IsTouchingLayers(LayerMask.GetMask("Interactables"))))
        {
            // Switch the control scheme depending on what vampire you're controlling
            switch (vampSelected)
            {
                case vampOptions.TOP_VAMPIRE:
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                        jumped = true;
                    }

                    break;
                case vampOptions.BOTTOM_VAMPIRE:
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                        jumped = true;
                    }

                    break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Border" ||
            collision.gameObject.name == "Interactables" ||
            collision.gameObject.name == "Hazard")
        {
            jumped = false;
        }
    }
}
