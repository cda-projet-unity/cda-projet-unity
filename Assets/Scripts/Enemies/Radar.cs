using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player")) Debug.Log("Couillon détecté .... Exterminate");
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player")) Debug.Log("Couillon perdu de vue");
    }
}
