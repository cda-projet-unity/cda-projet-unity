using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAggro : MonoBehaviour
{
    // This script is attached to the flying enemy to trigger the aggro animation
    private Animator anim;
    private Rigidbody2D rb;
    private bool playerInSight = false;
    private Vector3 initialPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;    
    }

    // Quand le joueur entre dans le trigger, l'animation d'aggro se lance  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("EndAggro", false);
            playerInSight = true;
            PlayerInSight();
            StartCoroutine(MoveTowardsPlayer());

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
          if (collision.CompareTag("Player"))
          {
            playerInSight = false;
            anim.SetBool("EndAggro", true);
            StopCoroutine(MoveTowardsPlayer());
            ReturnToInitialPosition();
          }
    }
    
    private void PlayerInSight()
    {
        anim.SetTrigger("StartAggro");
    }

    private IEnumerator MoveTowardsPlayer()
    {
        // get the player position
        while (playerInSight == true)
          {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                yield break;
            }

            Vector3 playerPosition = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void ReturnToInitialPosition()
    {
        // made the bat return to its initial position
        transform.position = Vector2.MoveTowards(transform.position, initialPosition, 0.05f);

    }



}

