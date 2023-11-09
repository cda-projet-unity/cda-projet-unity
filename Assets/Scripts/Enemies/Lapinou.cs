using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapinou : Enemy
{

    Vector2 startPos;
    bool lookRight = true;
    SpriteRenderer sp;

    void Start()
    {
        startPos = transform.position;
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (Vector2.Distance(startPos, transform.position) <= .5f && !lookRight) FlipCharacter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointRetour"))
        {
            Debug.Log("coucou");
            FlipCharacter();
        }
    }



    void FlipCharacter()
    {
        sp.flipX = !sp.flipX;
        speed = -speed;
        lookRight = !lookRight;
    }
}

