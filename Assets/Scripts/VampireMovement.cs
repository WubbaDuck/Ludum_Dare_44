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

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D thisCollider;
    private Animator anim;
    private HealthManager hm;

    private float moveSpeed = 6f;
    private float jumpPower = 25.0f;
    private bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        hm = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>() && !hm.IsVampireDead())
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
                if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    anim.SetBool("Walking", false);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D)) // Move Right
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                        sr.flipX = false;
                        anim.SetBool("Walking", true);
                    }

                    if (Input.GetKey(KeyCode.A)) // Move Left
                    {
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                        sr.flipX = true;
                        anim.SetBool("Walking", true);
                    }
                }
                break;
            case vampOptions.BOTTOM_VAMPIRE:
                // Stop horizontal movement if horizontal keys are not pressed or both are pressed
                if (!(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    anim.SetBool("Walking", false);
                }
                else
                {
                    if (Input.GetKey(KeyCode.RightArrow)) // Move Right
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                        sr.flipX = false;
                        anim.SetBool("Walking", true);
                    }

                    if (Input.GetKey(KeyCode.LeftArrow)) // Move Left
                    {
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                        sr.flipX = true;
                        anim.SetBool("Walking", true);
                    }
                }
                break;
        }
    }

    void Jump()
    {
        // Don't allow jumping unless the vampire is touching the ground or an interactable object
        if (!jumped && (thisCollider.IsTouchingLayers(LayerMask.GetMask("Border", "Interactables", "Hazards"))))
        {
            // Switch the control scheme depending on what vampire you're controlling
            switch (vampSelected)
            {
                case vampOptions.TOP_VAMPIRE:
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                        jumped = true;
                        anim.SetTrigger("Jumped");
                    }

                    break;
                case vampOptions.BOTTOM_VAMPIRE:
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                        jumped = true;
                        anim.SetTrigger("Jumped");
                    }

                    break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.IsTouchingLayers(LayerMask.GetMask("Border", "Interactables", "Hazards")))
        {
            jumped = false;
        }
    }
}
