using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private bool isCrouching;

    Animator animator;

    public LogicScript logic;

    void Start()
    {
        if (myRigidBody == null)
        {
            myRigidBody = GetComponent<Rigidbody2D>();
        }

        animator = GetComponent<Animator>();

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
        }

        myRigidBody.velocity = new Vector2(moveDirection * moveSpeed, myRigidBody.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }

        // Crouching
        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            isCrouching = true;
            animator.SetBool("isCrouching", true);
        }
        else
        {
            isCrouching = false;
            animator.SetBool("isCrouching", false);
        }

        animator.SetFloat("xVelocity", Mathf.Abs(myRigidBody.velocity.x));
    }

    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity", myRigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("Pumpkin"))
        {
            logic.gameOver();
        }

        if (collision.gameObject.CompareTag("Corn"))
        {
            logic.restartGame();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }
}
