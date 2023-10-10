using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAggro : MonoBehaviour
{

    private Animator animator;
    private bool playerInSight = false;


    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
         playerInSight = true;
         PlayerInSight();

        }

    }

  private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInSight = false;
            PlayerOutOfSight();
        }
    }

    private void PlayerInSight()
    {
        Debug.Log("Player in sight");
        Invoke("attack", 1f);
    }

    private void attack ()
    {
        animator.SetTrigger("PlayerInSight");
        Debug.Log("Attack");
        animator.SetTrigger("WaitOnSpike");
        Invoke("DisableSpikes", 1f);
    }

    

    private void DisableSpikes()
    {
        animator.SetTrigger("DisableSpikes");
    }

    private void PlayerOutOfSight()
    {
        Debug.Log("Player out of sight");
        animator.SetTrigger("PlayerOutOfSight");
    }

}
