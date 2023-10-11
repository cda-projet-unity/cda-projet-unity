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
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        if (attacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosition.x, transform.position.y), Time.deltaTime);
        }
    }
}
