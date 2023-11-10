using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] CanvasGroup cGroup;
    private int level;
    

    void Start()
    {
        level = PlayerStats.playerStats.GetScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish line");
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Level Completed");
        cGroup.GetComponent<LevelTransition>().SetAlphaValue(1);
    }

}
