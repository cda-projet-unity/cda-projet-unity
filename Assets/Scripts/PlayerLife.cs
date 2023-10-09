using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // OnCollisionEnter2D is called when this collider/rigidbody has begun touching another rigidbody/collider

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {   
            Debug.Log("Player hit a trap");
            Die();
        }
    }

    private void Die()
    {
        // Destroy the player
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("TriggerDeath");
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
