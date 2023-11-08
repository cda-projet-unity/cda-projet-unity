using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Debug.Log("Couillon détecté .... Exterminate");
            gameObject.GetComponentInParent<Lapinou>().CouillonSpotted();
        }
    }
}
