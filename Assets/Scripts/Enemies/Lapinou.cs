using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapinou : MonoBehaviour
{ {
    [SerializeField] float speed = 2f;

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
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (Vector2.Distance(startPos, transform.position) <= .5f && !lookRight) FlipCharacter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointRetour"))
        {
            FlipCharacter();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject contact = collision.gameObject;
        if (contact.CompareTag("Player") && contact.GetComponent<KnightScript>().OnAttack)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(deathSound);
            Death();
        }
        else if (contact.CompareTag("Player"))
        {
            DealDamage(contact);
        }
    }

    void FlipCharacter()
    {
        sp.flipX = !sp.flipX;
        speed = -speed;
        lookRight = !lookRight;
    }
}
}
