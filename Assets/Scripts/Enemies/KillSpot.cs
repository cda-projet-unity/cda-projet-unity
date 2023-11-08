using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Debug.Log("Couillon d�tect� .... Exterminate");
            gameObject.GetComponentInParent<Lapinou>().CouillonSpotted();
        }
    }
}
