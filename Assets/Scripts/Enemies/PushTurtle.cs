using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTurtle : MonoBehaviour
{
    [SerializeField] private float forceAmount;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hitPos in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (hitPos.normal.x > 0)
                {
                    rb.AddForce(Vector2.right * forceAmount);
                }
                if (hitPos.normal.x < 0)
                {
                    rb.AddForce(-Vector2.right * forceAmount);
                }
            }
        }
    }

}
