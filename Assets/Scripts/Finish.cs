using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public string nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish line");
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Level Completed");

        SceneManager.LoadScene(nextLevelName);
    }

}
