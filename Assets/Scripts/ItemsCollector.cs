using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To use UI text
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Script to collect items when colide 
    
    private int cherries = 0;

    // Get my text component
    [SerializeField] private Text CherryText;

    private void OnTriggerEnter2D(Collider2D collision ) {

        if(collision.gameObject.CompareTag("Cherry"))   
        {
            Destroy(collision.gameObject);
            cherries++;
            // Update text
            CherryText.text = "Compteur de couilles :" + cherries.ToString();
        }
        
    }
}
    