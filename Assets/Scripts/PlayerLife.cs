using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rb;
    private UIManager uiManager;
    [SerializeField] private AudioSource hitSoundEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Traps"))
        {
            hitSoundEffect.Play();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("TriggerDeath");
            Debug.Log("Player hit an enemy");
            Invoke("Die", 0.7f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {   
            hitSoundEffect.Play();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("TriggerDeath");
            Debug.Log("Player hit a trap");
            Invoke("Die", 0.7f);
        }
    }

    private void Die()
    {
        // Destroy the player
        PlayerStats.playerStats.ResetScore();
        uiManager.GameOver();
    }

    // Restart is triggered by an event on animation ending  
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
