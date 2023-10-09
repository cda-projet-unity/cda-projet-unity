using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    // init some types 

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Animator anim;
    private float dirX;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;

    private enum MovementState { idle, running, jumping, falling}    

    [SerializeField] private LayerMask jumpableGround;

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

        // make the player move
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

   
        // jump if clicked on the space key le jeu est en 2d (en  dur )

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2( rb.velocity.x, jumpForce);      
        
        }

        UpdateAnimation();
    }


    private void UpdateAnimation(){

        MovementState movementState;

        // check if the player is moving
        if (dirX > 0f)
        {
            movementState = MovementState.running;
            sr.flipX = false;
        }
        // check if the player is moving
        else if (dirX < 0f)
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
        if(rb.velocity.y > .1f)
        {
            movementState = MovementState.jumping;
        }
        // check if the player is falling
        else if(rb.velocity.y < -.1f)
        {
            movementState = MovementState.falling;
        }
        // set the animation
        anim.SetInteger("movementState", (int)movementState);
      
    }


    // return true if the player is grounded
    private bool IsGrounded(){
            // check if the player is grounded
            // here we create a boxcast to check if the player is grounded who has 
           return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
 