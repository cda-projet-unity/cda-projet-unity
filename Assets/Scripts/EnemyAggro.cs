using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAggro : MonoBehaviour
{

    private Animator anim;
    public bool playerInSight = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
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

    public void PlayerInSight()
    {
        Debug.Log("PlayerInSight");
        playerInSight = true;
        StartCoroutine(AttackPlayer());
    }

    private IEnumerator AttackPlayer()
    {
        while (playerInSight)
        { 
            anim.SetTrigger("PlayerInSight");
            gameObject.tag = "Traps";
            anim.SetTrigger("WaitOnSpike");
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("DisableSpikes");
            gameObject.tag = "Untagged";
            yield return new WaitForSeconds(2.5f);
        }
        
    }

    private void DisableSpikes()
    {
        anim.SetTrigger("DisableSpikes");
    }

    public void PlayerOutOfSight()
    {
        playerInSight = false;
        StopCoroutine(AttackPlayer());
        anim.SetTrigger("PlayerOutOfSight");
    }

}
