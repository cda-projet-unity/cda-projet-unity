using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float aggroRange;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected int scoreAmount;
    private bool scoreUpdated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hitPos in collision.contacts)
        {
            if (hitPos.normal.y < 0)
            {
                speed = 0;
                Death();
            }
        }
    }

    public void Death()
    {
        Debug.Log("Aaaargh !");
        if (!scoreUpdated)
        {
            PlayerStats.playerStats.UpdateScore(scoreAmount);
            scoreUpdated = true;
        }
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
