using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapinou : MonoBehaviour
{
    private bool attacking = false;
    public void CouillonSpotted()
    {
        attacking = true;
    }

    private void Update()
    {
        if (attacking)
        {
            //transform.Translate(GameObject.Find("Player");
        }
    }
}
