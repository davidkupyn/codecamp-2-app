using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Animator animator;

    [Header("Controls")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce = 12f;

    [Header("Settings")]
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = true;
    private bool isJumping = true;


    private int jumpCount = 1;



    void FixedUpdate()
    {
        CheckGround();
        Move();
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount -= 1;
            Jump();
        }

    }
    private void Move()
    {
        float movementX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * movementSpeed * Time.deltaTime;
        if (!Mathf.Approximately(movementX, 0))
        {
            transform.rotation = movementX < 0 ? new Quaternion(0, 180, 0, 0) : Quaternion.identity;
        }
        animator.SetFloat("move", Mathf.Abs(movementX));

    }
    private void Jump()
    {
        rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
<<<<<<< Updated upstream:CodeCamp2/Assets/PlayerController.cs
=======
    private void Move()
    {
        float movmentX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movmentX, 0, 0) * (movmentSpeed * Time.deltaTime);
>>>>>>> Stashed changes:CodeCamp2/Assets/PlayerMovment.cs


    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
        animator.SetBool("isJumping", !isGrounded);

        if (isGrounded)
        {
            jumpCount = 1;
        }
    }


}
