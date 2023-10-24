using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce = 35f;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    float input;
    bool facingRight = true;
    Animator anim;

    bool isGrounded;
    bool isJump;
    Transform groundCheck;
    float checkRadio = 0.3f;

    bool isTouchingFront;
    Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    public LayerMask wallLayer;

    bool walljumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumTime;

    bool dobleJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        groundCheck = transform.Find("Ground");
        frontCheck = transform.Find("FrontCheck");
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input > 0 && !facingRight)
        {
            Flip();
        }
        else if (input < 0 && facingRight)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadio, groundLayer);
        if (isGrounded)
        {
            dobleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isJump = true;
                dobleJump = true;
            }
            else if (dobleJump)
            {
                isJump = true;
                dobleJump = false;
                anim.SetTrigger("isDoble");
            }
        }


        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadio, wallLayer);
        if (isTouchingFront && !isGrounded && input != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallSliding)
        {
            walljumping = true;
            Invoke("SetWallJumpingToFalse", wallJumTime);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if (isJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJump = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (walljumping)
        {
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
        }
    }

    void LateUpdate()
    {
        anim.SetBool("isRunning", input != 0);
        anim.SetBool("isJump", !isGrounded);
        anim.SetFloat("VerticalVelocity", rb.velocity.y);
        anim.SetBool("isWall", isTouchingFront);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void SetWallJumpingToFalse()
    {
        walljumping = false;
    }
}