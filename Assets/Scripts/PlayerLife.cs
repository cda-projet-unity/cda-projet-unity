using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private UIManager uiManager;
    [SerializeField] private GameObject canvasTransition;
    [SerializeField] private AudioSource hitSoundEffect;
    private PlayersMovement pm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        uiManager = FindObjectOfType<UIManager>();
        pm = FindObjectOfType<PlayersMovement>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            hitSoundEffect.Play();
            pm.FreezeCrampo();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Traps");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            anim.SetTrigger("TriggerDeath");
            Debug.Log("Player hit an enemy");
            Invoke("Die", 0.7f);
            canvasTransition.SetActive(true);
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
