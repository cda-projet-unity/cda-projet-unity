using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroZone : MonoBehaviour
{

    [SerializeField] private bool playerInSight = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
EnemyAggro enemyAggro = GetComponent<EnemyAggro>();

// Appelle la fonction PlayerInSight de l'instance de EnemyAggro
         enemyAggro.PlayerInSight();
            playerInSight = true;
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
          if (collision.CompareTag("Player"))
          {
              playerInSight = false;
          }
    }

}
