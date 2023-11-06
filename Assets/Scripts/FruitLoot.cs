using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitLoot : MonoBehaviour
{
    private Transform player;
    private bool isLooting = false;
    private float t = 0.1f;
    [SerializeField] private int scoreAmount = 10;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (isLooting)
        {
            t += .1f;
            transform.position = Vector2.Lerp(transform.position, player.position, t * Time.deltaTime);
            if (Vector2.Distance(player.position, transform.position) <= .2f) StartCoroutine(Loot());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("lootin fruit");
        isLooting = true;
    }

    IEnumerator Loot()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("updating");
        PlayerStats.playerStats.UpdateScore(scoreAmount);
        Destroy(gameObject);
    }
}
