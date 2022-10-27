using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" Variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    // Private Variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded = true;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GroundCheck() && Input.GetButtonDown("Crouch"))
        {
            anim.SetBool("isDucking", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            anim.SetBool("isDucking", false);
        }
    }

    // Physics
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        isGrounded = GroundCheck();

        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            anim.SetBool("isGrounded", false);
            rBody.AddForce(new Vector2(0.0f, jumpForce));
        }

        rBody.velocity = new Vector2 (horiz * speed, rBody.velocity.y);

        if (isFacingRight && rBody.velocity.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }

        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("ySpeed", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}
