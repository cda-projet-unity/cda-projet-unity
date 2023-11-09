using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use UI text
using UnityEngine.UI;

// Script to collect items when colide 
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource cherrySoundEffect;
    [SerializeField] private Text CherryText;
    private int cherries = 0;

    private void OnTriggerEnter2D(Collider2D collision ) {

        if(collision.gameObject.CompareTag("Cherry"))   
        {
            Destroy(collision.gameObject);
            cherrySoundEffect.Play();
            cherries++;
            // Update text
            CherryText.text = "Compteur de couilles :" + cherries.ToString();
        }  
    }
}
    