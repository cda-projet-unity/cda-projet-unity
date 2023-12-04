using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : Enemy
{
    // get anim to play death animation on trigger isDying
    private Animator anim;
    Vector2 startPos;
    bool lookRight = true;
    SpriteRenderer sp;
    private bool facingRight = true; // Variable to keep track of the direction the rabbit is facing

    public void Start()
    {
        startPos = transform.position;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        Move(); // Call the Move method to handle movement
        if (Vector2.Distance(startPos, transform.position) <= .5f && !lookRight) FlipCharacter();
    }

    public void Move()
    {
        Vector2 movement = Vector2.right * Time.deltaTime * speed;
        transform.Translate(movement);

        // Update sprite direction based on movement
        if (movement.x > 0 && !facingRight || movement.x < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointRetour"))
        {
            FlipCharacter();
        }
    }

    public void FlipCharacter()
    {
        sp.flipX = !sp.flipX;
        speed = -speed;
        lookRight = !lookRight;
        facingRight = !facingRight; // Update sprite direction
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hitPos in collision.contacts)
        {
            if (hitPos.normal.y < 0)
            {
                //debug
                Debug.Log("Rhino hit ground");
            }
            else if (collision.gameObject.CompareTag("Player") && hitPos.normal.x < 0 || collision.gameObject.CompareTag("Player") && hitPos.normal.x > 0)
            {
                // change his tag to "Traps"
                gameObject.tag = "Traps";
                gameObject.tag= "Untagged";
                // freeze rhino pos
                // Destroy(gameObject);
                //debug
                Debug.Log("Player hit by Rhino");
            }
        }
    }


}

