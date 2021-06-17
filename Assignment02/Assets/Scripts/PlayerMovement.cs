using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 1;
    public int jumpForce = 4;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float checkRadius;


    private bool facingRight = false; //player is facing left to begin with
    private float moveInput;
    private Rigidbody2D rbody;
    private bool isGrounded;
    private bool isAttacking;
    private PlayerAnim anim;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnim>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player movement
        moveInput = Input.GetAxis("Horizontal");
        rbody.velocity = new Vector2(moveInput * playerSpeed, rbody.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


    }

    private void Update()
    {
        if(isGrounded == true)
        {
            anim.UpdateAnimator("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) //player has to be on ground if jumping
        {
            rbody.velocity = Vector2.up * jumpForce; // shorthand for creating an vector2 where x is 0 and y is 1, multiply by jumpForce
            anim.UpdateAnimator("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.X) && isAttacking ==false)
        {
            isAttacking = true;
            anim.UpdateAnimator("IsAttacking", true);
        }

        if (rbody.velocity.x == 0)
        {
            anim.UpdateAnimator("IsIdle", true);
        }
        else
        {

            anim.UpdateAnimator("IsIdle", false);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.UpdateAnimator("IsCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.UpdateAnimator("IsCrouching", false);
        }



    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale; //take GObj scales
        scaler.x *= -1; //flip along x axis.
        transform.localScale = scaler; //make this flip the new norm
    }


}
