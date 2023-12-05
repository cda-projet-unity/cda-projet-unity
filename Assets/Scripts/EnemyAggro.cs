using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAggro : MonoBehaviour
{

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(AttackPlayer());
    }

  
 

    private IEnumerator AttackPlayer()
    {
        while (true)
        { 
            anim.SetTrigger("PlayerInSight");
            gameObject.tag = "Traps";
            anim.SetTrigger("WaitOnSpike");
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("DisableSpikes");
            gameObject.tag = "Untagged";
            yield return new WaitForSeconds(2.5f);
            StopCoroutine(AttackPlayer());
        }        
    }

    private void DisableSpikes()
    {
        anim.SetTrigger("DisableSpikes");
    }  

}
