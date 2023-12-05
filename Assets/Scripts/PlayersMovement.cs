using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersMovement : MonoBehaviour
{
    // init some types 
    private enum MovementState { idle, running, jumping, falling }

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Animator anim;
    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;

    // mini joystick
    [SerializeField] private InputActionReference moveAction;

    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpableGround = LayerMask.GetMask("Ground");

    }



    // Update is called once per frame
    private void Update()
    {
        /*   // make the player move
           dirX = Input.GetAxisRaw("Horizontal");
           // Ensure the Rigidbody2D is not static
           if (rb.bodyType != RigidbodyType2D.Static)
           {
               rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
           }
           // jump 
           if(Input.GetButtonDown("Jump") && IsGrounded())
           {
               jumpSoundEffect.Play();
               rb.velocity = new Vector2( rb.velocity.x, jumpForce);      
           }
           UpdateAnimation();
        */
        Vector2 moveDirection = moveAction.action.ReadValue<Vector2>();
        Vector2 horizontalDirection = new Vector2(moveDirection.x, 0);
        transform.Translate(Time.deltaTime * moveSpeed * horizontalDirection);
        UpdateAnimation(moveDirection);
    }

    public void OnJumpTap()
    {
        if (IsGrounded())
        {
            rb.velocity = (new Vector2(rb.velocity.x, jumpForce));
        }
    }

    private void UpdateAnimation(Vector2 movementDirection)
    {

        MovementState movementState;

        // check if the player is moving
        if (movementDirection.x > 0f)
        {
            movementState = MovementState.running;
            sr.flipX = false;
        }
        // check if the player is moving
        else if (movementDirection.x < 0f)
        {
            movementState = MovementState.running;
            sr.flipX = true;
        }
        // check if the player is not moving
        else
        {
            movementState = MovementState.idle;
        }
        // check if the player is jumping
        if (rb.velocity.y > .1f)
        {
            movementState = MovementState.jumping;
        }
        // check if the player is falling
        else if (rb.velocity.y < -.1f)
        {
            movementState = MovementState.falling;
        }
        // set the animation
        anim.SetInteger("movementState", (int)movementState);

    }


    // return true if the player is grounded
    private bool IsGrounded()
    {
        // check if the player is grounded
        // here we create a boxcast to check if the player is grounded 
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
