using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Transform groundCheck;
    //[SerializeField] private Animator animator;

    [Header("Controls")]
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float jumpForce = 5f;

    [Header("Settings")]
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        CheckGround();
        Move();
    }
    private void Jump()
    {
        rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    private void Move()
    {
        float movmentX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movmentX, 0, 0) * movmentSpeed * Time.deltaTime;

        if (Mathf.Approximately(movmentX, 0) == false)
        {
            if (movmentX < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }

       // animator.SetFloat("move", Mathf.Abs(movmentX));
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
       // animator.SetBool("isJumping", !isGrounded);
    }
}
