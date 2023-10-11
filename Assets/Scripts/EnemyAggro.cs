using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAggro : MonoBehaviour
{

    private Animator anim;
    private bool playerInSight = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerInSight()
    {
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

    private void PlayerOutOfSight()
    {
        StopCoroutine(AttackPlayer());
        anim.SetTrigger("PlayerOutOfSight");
    }

}
